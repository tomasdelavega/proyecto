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
using System.Collections.ObjectModel;
using ClienteFisio.Interfaz.Terapias;
using System.ServiceModel;
using ClienteFisio.ClientWCF;
using ClienteFisio.Interfaz.Citas;

namespace ClienteFisio.Interfaz.Pacientes
{
    /// <summary>
    /// Interaction logic for VNuevoTratamiento.xaml
    /// </summary>
    public partial class VNuevoTratamiento : Window
    {
        private List<TTerapia> listTerapias;
        private int idHistorial;
        private TPaciente paciente;
        private String nomDiag;
        public VNuevoTratamiento(int idHist, TPaciente p, String nomD)
        {
            nomDiag = nomD;
            idHistorial = idHist;
            paciente = p;
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Activate();
            this.Owner.IsEnabled = true;

         
        }

        private void btnIniTrat_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                lblAvisos.Content = "";
                try
                {
                    TTratamiento t = new TTratamiento();
                    t.Estado = "Abierto";
                    t.F_inicio = calendar1.SelectedDate.Value;
                    t.Id_historial = idHistorial;
                    t.Observaciones = txtObs.Text;
                    t.Id_terapia = listTerapias.ElementAt(comboBox1.SelectedIndex).Id;


                    ClienteWCF.getServicios().registrarTratamiento(t,paciente.Dni, calendar1.SelectedDate.Value);

                    ((VHistorial)this.Owner).actualizarTerapias();
                    ((VHistorial)this.Owner).actualizarTratamientos();
                    this.Close();
                }
                catch (FaultException<ErrorSql> ex)
                {
                    MessageBox.Show(ex.Detail.Content);
                }
                catch (EndpointNotFoundException ex)
                {
                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                }
                catch (FaultException<Error> ex)
                {
                    if (ex.Detail.Content == "Ya se ha aplicado esta terapia a este diagnóstico.")
                        lblAvisos.Content = "Ya se ha aplicado esta terapia a este diagnóstico.";
                    else
                    {
                        // MessageBox.Show(ex.Detail.Content);
                        MessageBoxResult r = MessageBox.Show(ex.Detail.Content, "", MessageBoxButton.YesNo, MessageBoxImage.Information);
                        if (r == MessageBoxResult.Yes)
                        {
                            /* TSesionCita s = new TSesionCita();
                             s.Dni_paciente = paciente.Dni;
                             DateTime time = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, System.DateTime.Now.Hour, 0, 0);
                      
                             s.Fecha = time;
                             s.Id_historial = idHistorial;
                             s.Pagado = false;
                             s.Precio = ClienteFisio.Properties.Settings.Default.precio;
                             s.Id_terapia = listTerapias.ElementAt(comboBox1.SelectedIndex).Id;

                             try
                             {
                                 ClienteWCF.getServicios().registrarCita(s);
                                 MessageBox.Show("Sesión creada, inicia ahora el tratamiento.");
                        
                             }
                             catch (FaultException<ErrorSql> exc)
                             {
                                 MessageBox.Show(exc.Detail.Content);
                             }
                             catch (EndpointNotFoundException exc)
                             {
                                 MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                             }*/
                            VCitas v = new VCitas(calendar1.SelectedDate.Value);
                            v.Owner = this;
                            this.IsEnabled = false;
                            v.Show();

                        }
                    }
                }
            }
            else
                lblAvisos.Content = "Elige la terapia que se aplicará.";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            calendar1.SelectedDate = System.DateTime.Now;
            lblNom.Content = paciente.Nombre + " " + paciente.Apellidos;
            lblDiag.Content = "Diagnóstico: " + nomDiag;
            try
            {
                listTerapias = ClienteWCF.getServicios().recuperarTerapias();
                if (listTerapias == null)
                {
                    lblAvisos.Content = "No hay terapias en la base de datos.";
                    listTerapias = new List<TTerapia>();
                }
                else
                    foreach (TTerapia t in listTerapias)
                        comboBox1.Items.Add(t.Nombre);

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");
                this.Close();
            }
        }

        private void btnañadir_Click(object sender, RoutedEventArgs e)
        {
            VTerapias v = new VTerapias();
            v.Owner = this;
            this.IsEnabled = false;
            v.bloquearElim();
            v.Show();
        }

        public void actualizarTerapias()
        {
            listTerapias.Clear();
            comboBox1.Items.Clear();
            try
            {
                listTerapias = ClienteWCF.getServicios().recuperarTerapias();
                if (listTerapias == null)
                {
                    lblAvisos.Content = "No hay terapias en la base de datos.";
                    listTerapias = new List<TTerapia>();
                }
                else
                    foreach (TTerapia t in listTerapias)
                        comboBox1.Items.Add(t.Nombre);

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");
                this.Close();
            }
        }

        

        
    }
}
