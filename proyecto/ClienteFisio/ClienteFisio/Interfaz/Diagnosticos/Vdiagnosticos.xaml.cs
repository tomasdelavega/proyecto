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
using ClienteFisio.Interfaz.Pacientes;

namespace ClienteFisio.Interfaz.Diagnosticos
{
    /// <summary>
    /// Interaction logic for Vdiagnosticos.xaml
    /// </summary>
    public partial class Vdiagnosticos : Window
    {
        List<TDiagnostico> diagnosticos;
        public Vdiagnosticos()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.cargar();
        
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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (listD.SelectedIndex != -1)
            {
                TDiagnostico d = this.diagnosticos.ElementAt(listD.SelectedIndex);
                MessageBoxResult r = MessageBox.Show("¿Está seguro de que desea eliminar el diagnóstico '" + d.Nombre + "'", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().eliminarDiagnostico(d.Id);
                        diagnosticos.Remove(d);
                        listD.Items.Remove(listD.SelectedItem);
                        txtDescripcion.Text = "";
                        txtNombre.Text = "";
                        lblMensaje.Content = "Diagnóstico'" + d.Nombre + "' eliminado.";

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

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtNombre.Text == "")
                lblMensaje.Content = "El campo nombre es obligaritorio, rellénelo.";
            else
            {
                try
                {
                    TDiagnostico diag = new TDiagnostico();
                    lblMensaje.Content = "";
                    diag.Nombre = txtNombre.Text;
                    diag.Descripcion = txtDescripcion.Text;
                    ClienteWCF.getServicios().nuevoDiagnostico(diag);
                    lblMensaje.Content = "Diagnóstico'" + diag.Nombre + "' agregado.";
                    
                    

                    if (this.Owner is VNuevoHist)
                    {
                      
                        ((VNuevoHist)this.Owner).actualizar();
                        this.Close();
                    }
                    listD.Items.Clear();
                    this.cargar();
                    if(listD.Items.Count > 0)
                        listD.SelectedIndex = 0;
                    
            
                }
                catch (FaultException<Error> ex)
                {
                   lblMensaje.Content = ex.Detail.Content;
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
        private void cargar()
        {
            
            try
            {
                this.diagnosticos = ClienteWCF.getServicios().recuperarDiagnosticos();
                if (diagnosticos == null)
                {
                    lblMensaje.Content = "No hay diagnósticos";
                    this.diagnosticos = new List<TDiagnostico>();
                }
                else
                {
                    foreach (TDiagnostico d in diagnosticos)
                    {
                        listD.Items.Add(d.Nombre);
                    }
                }

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

        public void bloquearElim()
        {
            btnEliminar.IsEnabled = false;
        }

        private void listD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listD.SelectedIndex != -1)
            {
                TDiagnostico d = diagnosticos.ElementAt(listD.SelectedIndex);
                txtNombre.Text = d.Nombre;
                txtDescripcion.Text = d.Descripcion;
            }
        }

    }
}
