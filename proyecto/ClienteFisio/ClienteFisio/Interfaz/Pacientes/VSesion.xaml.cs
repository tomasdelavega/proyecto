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
using ClienteFisio.Interfaz.Citas;

namespace ClienteFisio.Interfaz.Pacientes
{
    /// <summary>
    /// Interaction logic for VSesion.xaml
    /// </summary>
    public partial class VSesion : Window
    {
        private TSesionCita sesion;
        private String nomDiag = "Error BD";
        private String nomTerap = "Error BD";
        private TPaciente paciente = new TPaciente();
        public VSesion(TSesionCita sesion)
        {
            InitializeComponent();
            this.sesion = sesion;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBox1.Items.Add("9");
            comboBox1.Items.Add("10");
            comboBox1.Items.Add("11");
            comboBox1.Items.Add("12");
            comboBox1.Items.Add("13");
            comboBox1.Items.Add("16");
            comboBox1.Items.Add("17");
            comboBox1.Items.Add("18");
            comboBox1.Items.Add("19");
            comboBox1.Items.Add("20");
            comboBox1.Items.Add("21");
            textBox1.Text = sesion.Observaciones;
            lblHora.Content = "Hora: "+sesion.Fecha.Hour+":00";
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(sesion.Fecha.Hour.ToString());
            if (sesion.Pagado == true)
            {
                checkBox1.IsChecked = true;
                checkBox1.IsEnabled = false;
            }

            txtPrecio.Text = sesion.Precio.ToString();
            
                if (sesion.Id_historial != null)
                {
                    try
                    {
                        nomDiag = ClienteWCF.getServicios().getNomDiag(int.Parse(sesion.Id_historial.ToString()));
                        if (nomDiag == "***")
                            nomDiag = "*Eliminado*";


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
                else
                    nomDiag = "Sin diagnóstico";

                lblDiagnostico.Content = "Diagnóstico: " + nomDiag;

                if (sesion.Id_terapia != null)
                {
                    try
                    {
                        nomTerap = ClienteWCF.getServicios().getNomTerap(int.Parse(sesion.Id_terapia.ToString()));
                        if (nomTerap == null)
                            nomTerap = "*Eliminado*";
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
                else
                    nomTerap = "Sin terapia";

                lblTerapia.Content = "Terapia: " + nomTerap;


                try
                {
                    paciente = ClienteWCF.getServicios().getPaciente(sesion.Dni_paciente);
                    if (paciente == null)
                    {
                        lblTit.Content = sesion.Fecha.ToShortDateString();

                    }
                    else
                        lblTit.Content = paciente.Nombre + " " + paciente.Apellidos + " " + sesion.Fecha.ToShortDateString();


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

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            lblAvisos.Content = "";
            if (comboBox1.SelectedIndex != -1)
            {
                if(txtPrecio.Text != "")
                {
                    try
                    {
                        sesion.Precio = float.Parse(txtPrecio.Text);
                        if(checkBox1.IsChecked == true)
                            sesion.Pagado = true;
                        sesion.Observaciones = textBox1.Text;
                        DateTime t = new DateTime(sesion.Fecha.Year, sesion.Fecha.Month, sesion.Fecha.Day, int.Parse(comboBox1.SelectedItem.ToString()), 0, 0);
                        
                        sesion.Fecha = t;
                    
                        ClienteWCF.getServicios().modifSesion(sesion);
                        if (checkBox1.IsChecked == true)
                            checkBox1.IsEnabled = false;
                        lblAvisos.Content = "Sesión modificada.";
                        if (this.Owner is VTratamiento)
                            ((VTratamiento)this.Owner).cargarSesiones();
                        if (this.Owner is VCitas)
                        {
                            ((VCitas)this.Owner).limpiar();
                            ((VCitas)this.Owner).cargar2(((VCitas)this.Owner).getFechaCalendario());
                            this.Close();
                        }
                        if (this.Owner is VCuentas)
                        {
                            ((VCuentas)this.Owner).cargar();
                            this.Close();
                        }

                 /*   {
                        ((VCitas)this.Owner).limpiar();
                        ((VCitas)this.Owner).cargar2(((VCitas)this.Owner).getFechaCalendario());
                    }*/

                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);
                    }
                    catch(FormatException ex)
                    {
                        lblAvisos.Content = "Introduce correctamente el precio.";
                    }
                    catch (EndpointNotFoundException ex)
                    {
                        MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                    }
                }
                else
                    lblAvisos.Content = "Introduce un precio.";
            }
            else
                lblAvisos.Content = "Selecciona una hora.";
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
            {
                try
                {

                    ClienteWCF.getServicios().borrarCita(sesion.Id_cita);
                    if (this.Owner is VTratamiento)
                        ((VTratamiento)this.Owner).cargarSesiones();
                    if (this.Owner is VCitas)
                    {
                        ((VCitas)this.Owner).limpiar();
                        ((VCitas)this.Owner).cargar2(((VCitas)this.Owner).getFechaCalendario());
                    }
                    if (this.Owner is VCuentas)
                        ((VCuentas)this.Owner).cargar();
                    this.Close();
                    


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
    }
}
