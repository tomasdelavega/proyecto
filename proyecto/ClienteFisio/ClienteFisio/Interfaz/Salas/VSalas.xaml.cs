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

namespace ClienteFisio.Interfaz.Salas
{
    /// <summary>
    /// Lógica de interacción para Vañadir.xaml
    /// </summary>
    public partial class VSalas : Window
    {
        private List<TSala> salas;
        public VSalas()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Activate();
            this.Owner.IsEnabled = true;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            lblAvisos.Content = "";
            if (txtNombre.Text == "")
                lblAvisos.Content = "Debe introducir el nombre de la sala.";
            else
            {
                try
                {
                    lblAvisos.Content = "";
                    TSala s = new TSala();
                    s.Nombre = txtNombre.Text;
                    s.Descripcion = txtDescripcion.Text;
                    ClienteWCF.getServicios().nuevaSala(s);
                    lblAvisos.Content = s.Nombre + " agregada.";
                    comboSalas.Items.Add(s.Nombre);
                    salas.Add(s);
                }
                catch (FaultException<Error> ex)
                {
                    lblAvisos.Content = ex.Detail.Content;
                }
                catch (FaultException<ErrorSql> ex)
                {
                    MessageBox.Show(ex.Detail.Content);
                }
                catch (EndpointNotFoundException ex)
                {
                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                }
                
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.cargar();
        }

        private void cargar()
        {
          
            try
            {

                salas = ClienteWCF.getServicios().recuperarSalas();
                if (salas == null)
                {
                    lblAvisos.Content = "No hay salas en la base de datos.";
                    salas = new List<TSala>();
                }
                if (salas != null)
                {
                    foreach (TSala s in salas)
                    {
                        comboSalas.Items.Add(s.Nombre);

                    }

                }
                if (comboSalas.Items.Count > 0)
                    comboSalas.SelectedIndex = 0;

            }
            catch (FaultException<ErrorSql> ex)
            {
                MessageBox.Show(ex.Detail.Content);
                this.Close();
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");
                this.Close();
            }
           
        }

        private void comboSalas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboSalas.SelectedIndex != -1)
            {

                TSala sala = new TSala();
                sala = salas.ElementAt(comboSalas.SelectedIndex);
                txtNombre.Text = sala.Nombre;
                txtDescripcion.Text = sala.Descripcion;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (comboSalas.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Está seguro de que desea eliminar esta sala?","", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {
                        ClienteWCF.getServicios().eliminarSala(comboSalas.SelectedItem.ToString());
                        salas.RemoveAt(comboSalas.SelectedIndex);
                        comboSalas.Items.Remove(comboSalas.SelectedItem);

                        if (comboSalas.Items.Count > 0)
                            comboSalas.SelectedIndex = 0;
                        lblAvisos.Content = "Sala eliminada";
                    }
                    catch (FaultException<ErrorSql> ex)
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
    }
}
