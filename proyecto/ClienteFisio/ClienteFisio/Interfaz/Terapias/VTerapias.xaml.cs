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
using Microsoft.Win32;

namespace ClienteFisio.Interfaz.Terapias
{
    /// <summary>
    /// Interaction logic for Vagregaryeliminar.xaml
    /// </summary>
    public partial class VTerapias : Window
    {
        List<TTerapia> terapias;
        public VTerapias()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void cargar()
        {

            try
            {
                this.terapias = ClienteWCF.getServicios().recuperarTerapias();
                if (terapias == null)
                {
                    lblmensaje.Content = "No hay terapias";
                    this.terapias = new List<TTerapia>();
                }
                if (terapias != null)
                {
                    foreach (TTerapia t in terapias)
                    {
                        comboTerapias.Items.Add(t.Nombre);
                    }
                    comboTerapias.SelectedIndex = 0;
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

        private void btneliminar_Click(object sender, RoutedEventArgs e)
        {
            if (comboTerapias.SelectedIndex != -1)
            {
                TTerapia t = this.terapias.ElementAt(comboTerapias.SelectedIndex);
                MessageBoxResult r = MessageBox.Show("¿Está seguro de que desea eliminar la terapia '" + t.Nombre + "'?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {
                        ClienteWCF.getServicios().eliminarTerapia(t.Nombre);
                        terapias.Remove(t);
                        comboTerapias.Items.RemoveAt(comboTerapias.SelectedIndex);
                        lblmensaje.Content = "Terapia '" + t.Nombre + "' eliminada.";
                        if(comboTerapias.Items.Count > 0)
                            comboTerapias.SelectedIndex = 0;

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
            lblmensaje.Content = "";       
            if(txtnombre.Text == "")
                lblmensaje.Content = "El campo 'Nombre' es obligaritorio, rellénelo.";
            else 
            {

                try
                {
                    TTerapia tera = new TTerapia();
                    if(txtNums.Text!="")
                        tera.Numsesiones = int.Parse(txtNums.Text);
                    tera.Imagen = this.dividir(txtImagen.Text);
                    tera.Nombre = txtnombre.Text.ToString();
                    tera.Descripcion = txtdescripcion.Text.ToString();

                    ClienteWCF.getServicios().nuevaTerapia(tera);
                    lblmensaje.Content = "Terapia '" + tera.Nombre + "' agregada.";
                    comboTerapias.Items.Clear();
                    if (this.Owner is VNuevoTratamiento)
                    {
                        ((VNuevoTratamiento)this.Owner).actualizarTerapias();
                        this.Close();
                    }


                    this.cargar();
                }
                catch (FaultException<Error> ex)
                {
                    lblmensaje.Content = ex.Detail.Content;
                }
                catch (FaultException<ErrorSql> ex)
                {
                    MessageBox.Show(ex.Detail.Content);
                }
                catch (FormatException ex)
                {
                    lblmensaje.Content = "Solo se permiten digitos.";
                }
                catch (EndpointNotFoundException ex)
                {
                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");
                    
                }
            }
        }
        public void bloquearElim()
        {
            btneliminar.IsEnabled = false;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (comboTerapias.SelectedIndex != -1)
            {

                TTerapia t = this.terapias.ElementAt(comboTerapias.SelectedIndex);
                
                try
                {
                    if (txtNums.Text != "")
                        t.Numsesiones = int.Parse(txtNums.Text);
                   
                    t.Imagen = this.dividir(txtImagen.Text);
                    MessageBoxResult r = MessageBox.Show("¿Está seguro de que desea modificar la terapia '" + t.Nombre + "'?.", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (r == MessageBoxResult.Yes)
                    {
                        try
                        {

                            t.Descripcion = txtdescripcion.Text.ToString();
                            ClienteWCF.getServicios().modificarTerapia(t);
                            terapias.Insert(comboTerapias.SelectedIndex, t);
                            lblmensaje.Content = "Terapia '" + t.Nombre + "' modificada.";

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
                catch (FormatException ex)
                {
                    lblmensaje.Content = "Solo se permiten dígitos en el campo 'Nº Sesiones'.";
                }
            }
        }

        private void comboTerapias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboTerapias.SelectedIndex != -1)
            {
                TTerapia t = this.terapias.ElementAt(comboTerapias.SelectedIndex);
                txtnombre.Text = t.Nombre;
                txtdescripcion.Text = t.Descripcion;
                txtNums.Text = t.Numsesiones.ToString();
                txtImagen.Text = t.Imagen;
                //lblmensaje.Content = "";
            }
        }

        private void btnBuscarImg_Click(object sender, RoutedEventArgs e)
        {
            FileDialog d = new OpenFileDialog();
            d.ShowDialog();
            txtImagen.Text = d.FileName;
        }

        private String dividir(String str)
        {
            if (str != "")
            {

                char[] delimitador = { '\\' };
                String[] separado = str.Split(delimitador);

                int palabras = separado.Count();

                if (palabras < 2)
                    return str;
                else
                    return separado.ElementAt(palabras - 2) + "/" + separado.ElementAt(palabras - 1);
                
            }
            else
                return "";
        }

        
    }
}
