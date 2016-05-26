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
using System.ServiceModel;
using ClienteFisio.ClientWCF;
using System.Collections.ObjectModel;

namespace ClienteFisio.Interfaz.Pacientes
{
    /// <summary>
    /// Interaction logic for VSesiones.xaml
    /// </summary>
    /// 
    public partial class VTratamiento : Window
    {
        private ObservableCollection<SesData> _SesCollection = new ObservableCollection<SesData>();
        private TPaciente paciente;
        private TTratamiento tratamiento;
        private List<TSesionCita> listSesiones = new List<TSesionCita>();
        private String nomDiag;
        private String nomT;
        public VTratamiento(TPaciente p,TTratamiento t, String nomTerapia, String nomD)
        {
            this.nomT = nomTerapia;
            this.nomDiag = nomD;
            this.paciente = p;
            this.tratamiento = t;
            this.InitializeComponent();
        }
        public ObservableCollection<SesData> SesCollection
        { get { return _SesCollection; } }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (tratamiento.Estado != "Abierto")
                button1.IsEnabled = false;
            comboBox1.Items.Add("Satisfactorio");
            comboBox1.Items.Add("Fallido");
            comboBox1.SelectedIndex = 0;
            txtFIni.Text = tratamiento.F_inicio.ToShortDateString();
            textBox1.Text = tratamiento.Observaciones;
            lblTit.Content = paciente.Nombre + " " + paciente.Apellidos;
            lblTerapia.Content = "Terapia: " + nomT;
            lblDiagnostico.Content = "Diagnóstico: " + nomDiag;
            lblEstado.Content = "Estado: "+tratamiento.Estado;
            if (tratamiento.F_fin == null)
                txtffin.Text = "En curso";
            else
                txtffin.Text = tratamiento.F_fin.Value.ToShortDateString();

            try
            {
                listSesiones = ClienteWCF.getServicios().recuperarSesionesTrat(tratamiento.Id_historial, tratamiento.Id_terapia);
                if (listSesiones == null)
                {
                    listSesiones = new List<TSesionCita>();
                    lblavisos.Content = "No hay sesiones registradas.";
                }
                else
                    foreach (TSesionCita s in listSesiones)
                    {
                        String pagado = "Si";
                        if(!s.Pagado)
                            pagado = "No";
                        _SesCollection.Add(new SesData { Fecha = s.Fecha.ToString(), Pagado = pagado});
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
            this.Owner.Activate();
            this.Owner.IsEnabled = true;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            lblavisos.Content = "";
            try
            {
                tratamiento.Observaciones = textBox1.Text;
                ClienteWCF.getServicios().modifTratamiento(tratamiento);
                ((VHistorial)this.Owner).actualizarTratamientos();
                lblavisos.Content = "Tratamiento actualizado.";

               
            }
            catch (FaultException<ErrorSql> ex)
            {
                MessageBox.Show(ex.Detail.Content);
            }
            catch (FaultException<Error> ex)
            {
                lblavisos.Content = ex.Detail.Content;
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            lblavisos.Content = "";
            MessageBoxResult r = MessageBox.Show("¿Seguro que quieres finalizar el tratamiento como '"+comboBox1.SelectedItem.ToString()+ "'?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
            {
                try
                {
                    tratamiento.F_fin = System.DateTime.Now;
                    tratamiento.Estado = comboBox1.SelectedItem.ToString();
                    ClienteWCF.getServicios().cerrarTratamiento(tratamiento);
                    txtffin.Text = tratamiento.F_fin.Value.ToShortDateString();
                    lblEstado.Content = "Estado: " + tratamiento.Estado;
                    ((VHistorial)this.Owner).actualizarTratamientos();
                    lblavisos.Content = "Tratamiento cerrado.";


                }
                catch (FaultException<ErrorSql> ex)
                {
                    MessageBox.Show(ex.Detail.Content);
                }
                catch (FaultException<Error> ex)
                {
                    lblavisos.Content = ex.Detail.Content;
                }
                catch (EndpointNotFoundException ex)
                {
                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                }
            }

        }

        private void listViewSes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewSes.SelectedIndex != -1)
            {
                VSesion v = new VSesion(listSesiones.ElementAt(listViewSes.SelectedIndex));
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listViewSes.SelectedIndex = -1;
            }
        }

        public void cargarSesiones()
        {
            _SesCollection.Clear();
            try
            {
                listSesiones = ClienteWCF.getServicios().recuperarSesionesTrat(tratamiento.Id_historial, tratamiento.Id_terapia);
                if (listSesiones == null)
                {
                    listSesiones = new List<TSesionCita>();
                    lblavisos.Content = "No hay sesiones registradas.";
                }
                else
                    foreach (TSesionCita s in listSesiones)
                    {
                        String pagado = "Si";
                        if (!s.Pagado)
                            pagado = "No";
                        _SesCollection.Add(new SesData { Fecha = s.Fecha.ToString(), Pagado = pagado });
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
    }

    public class SesData
    {
        public string Fecha { get; set; }
        public string Pagado { get; set; }
       

    }
}
