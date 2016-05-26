using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClienteFisio.ClientWCF;
using System.ServiceModel;

namespace ClienteFisio.Interfaz.Materiales
{
    /// <summary>
    /// Interaction logic for VMateriales.xaml
    /// </summary>
    public partial class VMateriales : Window
    {
        private bool obtenidos = false;
        public VMateriales()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Activate();
            this.Owner.IsEnabled = true;

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnVer_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            lblAvisos.Content = "";
            if (listBoxMat.SelectedIndex == -1)
                lblAvisos.Content = "No hay ningún material selccionado.";
            else
            {
                MessageBoxResult result = MessageBox.Show("Quieres eliminar '" + listBoxMat.SelectedItem.ToString() + "'", " ", MessageBoxButton.YesNo, MessageBoxImage.Question);
               
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarMaterial(listBoxMat.SelectedItem.ToString());
                        
                        listBoxMat.Items.RemoveAt(listBoxMat.SelectedIndex);
                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);
                    }
                    catch (FaultException<Error> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);
                    }
                    catch (EndpointNotFoundException ex)
                    {
                        MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                    }
                    
                }
                
                
            }
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {

            if (txtAñadir.Text == "")
                lblAvisos.Content = "No hay nada que insertar";
            else
            {
                lblAvisos.Content = "";
                try
                {
                    ClienteWCF.getServicios().añadirMaterial(txtAñadir.Text);
                    lblAvisos.Content = "'" + txtAñadir.Text + "' añadido.";
                    listBoxMat.Items.Add(txtAñadir.Text);
                    txtAñadir.Text = "";

                }
                catch (FaultException<ErrorSql> ex)
                {
                    MessageBox.Show(ex.Detail.Content);
                }
                catch (FaultException<Error> ex)
                {
                    lblAvisos.Content = ex.Detail.Content;
                }
                catch (EndpointNotFoundException ex)
                {
                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                }
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!obtenidos)
            {
                lblAvisos.Content = "";
                try
                {
                    List<TMaterial> listMat = ClienteWCF.getServicios().recuperarMateriales();
                    if (listMat == null)
                        lblAvisos.Content = "No hay materiales en la base de datos";
                    else
                    {
                        foreach (TMaterial m in listMat)
                        {
                            listBoxMat.Items.Add(m.Nombre);
                        }
                        listBoxMat.SelectedIndex = 0;
                        obtenidos = true;
                    }

                }
                catch (FaultException<ErrorSql> ex)
                {
                    MessageBox.Show(ex.Detail.Content);
                }
                catch (EndpointNotFoundException ex)
                {
                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");
                    this.Close();
                }
            }

        }
    }
}
