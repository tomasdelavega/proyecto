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
    /// Interaction logic for VHistorial.xaml
    /// </summary>
    public partial class VHistorial : Window
    {
        private THistorial historial;
        private TPaciente paciente;
        private String nomDiagnostico;
        private List<TTratamiento> listTratamientos;
        private List<TTerapia> listTerapias;
        private ObservableCollection<TratData> _TratCollection = new ObservableCollection<TratData>();
        public VHistorial(THistorial h, TPaciente p, String nomD)
        {
            this.paciente = p;
            this.historial = h;
            this.nomDiagnostico = nomD;
            InitializeComponent();
        }
        public ObservableCollection<TratData> TratCollection
        { get { return _TratCollection; } }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
            ((VPacientes)this.Owner).setIndexM1();
            this.Owner.Activate();
            this.Owner.IsEnabled = true;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (historial.Estado == "Cerrado")
                btnCerrar.IsEnabled = false;
            lblTit.Content = paciente.Nombre + " "+ paciente.Apellidos;
            lblEstado.Content = "Estado: " + historial.Estado;
            lbldiagnostico.Content = "Diagnóstico: "+nomDiagnostico;
            if (historial.F_fin == null)
                txtFFin.Text = "En curso";
            else
                txtFFin.Text = historial.F_fin.Value.ToShortDateString();
            txtFini.Text = historial.F_inicio.ToShortDateString();
            txtZona.Text = historial.Zona;
            txtObs.Text = historial.Observaciones;

            try
            {
                listTerapias = ClienteWCF.getServicios().recuperarTerapias();
                if (listTerapias == null)
                {
                    listTerapias = new List<TTerapia>();
                    lblAvisos.Content = "No hay terapias en la base de datos.";
                }
                listTratamientos = ClienteWCF.getServicios().recuperarTratamientos(historial.Id);
                if (listTratamientos == null)
                {
                    listTratamientos = new List<TTratamiento>();
                    lblAvisos.Content = "No hay tratamientos para éste diagnóstico.";
                }
                else
                {
                    foreach (TTratamiento t in listTratamientos)
                    {
                        String fFin = "";
                        if (t.F_fin != null)
                            fFin = t.F_fin.Value.ToShortDateString();
                        TTerapia te = this.getTerapia(t.Id_terapia);
                        String nomT = "*Eliminado*";
                        if(te != null)
                            nomT = te.Nombre;
                       
                        _TratCollection.Add(new TratData {Terapia = nomT, Estado = t.Estado, FIni = t.F_inicio.ToShortDateString(), FFin = fFin });
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

        private TTerapia getTerapia(int id)
        {
            TTerapia tR = null;
            foreach (TTerapia t in listTerapias)
                if (t.Id == id)
                    return t;
            return tR;

        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            lblAvisos.Content = "";
            if (historial.Estado != "Cerrado")
            {
                if (!this.tratamientoAbierto())
                {

                    VNuevoTratamiento v = new VNuevoTratamiento(historial.Id, paciente, nomDiagnostico);
                    v.Owner = this;
                    this.IsEnabled = true;
                    v.Show();

                }
                else
                    lblAvisos.Content = "Ya hay un tratamiento abierto.";
            }
            else
                MessageBox.Show("El diagnóstico está cerrado.");
        }
        public void actualizarTerapias()
        {
            try
            {
                listTerapias = ClienteWCF.getServicios().recuperarTerapias();
                if (listTerapias == null)
                {
                    listTerapias = new List<TTerapia>();
                    lblAvisos.Content = "No hay terapias en la base de datos.";
                }
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");
                this.Close();
            }

        }
        public void actualizarTratamientos(TTratamiento t)
        {
        
            listTratamientos.Add(t);
            String fFin = "";
            if (t.F_fin != null)
                fFin = t.F_fin.Value.ToShortDateString();
            TTerapia te = this.getTerapia(t.Id_terapia);
            String nomT = "*Eliminado*";
            if (te != null)
                nomT = te.Nombre;

            _TratCollection.Add(new TratData { Terapia = nomT, Estado = t.Estado, FIni = t.F_inicio.ToShortDateString(), FFin = fFin });
        }

        private bool tratamientoAbierto()
        {
            bool abierta = false;
            foreach (TTratamiento t in listTratamientos)
                if (t.Estado == "Abierto")
                    return true;
            return abierta;
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("¿Seguro que quieres finalizar el diagnóstico?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
            {
                if (this.tratamientosFinalizados())
                {
                    try
                    {
                        lblAvisos.Content = "";
                        ClienteWCF.getServicios().cerrarDiagnostico(historial.Id);
                        lblEstado.Content = "Estado: Cerrado";
                        txtFFin.Text = System.DateTime.Now.ToShortDateString();
                        historial.F_fin = System.DateTime.Now;
                        historial.Estado = "Cerrado";
                        ((VPacientes)this.Owner).actualizarHistorial();
                        lblAvisos.Content = "Diagnóstico cerrado.";
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
                else
                    lblAvisos.Content = "Imposible cerrar el diagnóstico. Hay un tratamiento en curso.";
            }
        }

        private bool tratamientosFinalizados()
        {
            bool cerrados = true;
            foreach(TTratamiento t in listTratamientos)
                if(t.Estado == "Abierto")
                    cerrados = false;
            return cerrados;
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblAvisos.Content = "";
                historial.Zona = txtZona.Text;
                historial.Observaciones = txtObs.Text;
                ClienteWCF.getServicios().modifDiagnostico(historial);
                ((VPacientes)this.Owner).actualizarHistorial();
                lblAvisos.Content = "Diagnóstico actualizado.";
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

        public void actualizarTratamientos()
        {
            lblAvisos.Content = "";
            try
            {

                _TratCollection.Clear();
                
                listTratamientos = ClienteWCF.getServicios().recuperarTratamientos(historial.Id);
                if (listTratamientos == null)
                {
                    listTratamientos = new List<TTratamiento>();
                    lblAvisos.Content = "No hay tratamientos para éste diagnóstico.";
                }
                else
                {
                    foreach (TTratamiento t in listTratamientos)
                    {
                        String fFin = "";
                        if (t.F_fin != null)
                            fFin = t.F_fin.Value.ToShortDateString();
                        TTerapia te = this.getTerapia(t.Id_terapia);
                        String nomT = "*Eliminado*";
                        if (te != null)
                            nomT = te.Nombre;

                        _TratCollection.Add(new TratData { Terapia = nomT, Estado = t.Estado, FIni = t.F_inicio.ToShortDateString(), FFin = fFin });
                    }
                }
                listViewTrat.SelectedIndex = -1;




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

        private void listViewPac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewTrat.SelectedIndex != -1)
            {
                
                TTratamiento t = listTratamientos.ElementAt(listViewTrat.SelectedIndex);
                TTerapia te = this.getTerapia(t.Id_terapia);
                        String nomT = "*Eliminado*";
                        if (te != null)
                            nomT = te.Nombre;
                listViewTrat.SelectedIndex = -1;
                VTratamiento v = new VTratamiento(paciente, t, nomT, nomDiagnostico);
                v.Owner = this;
               
                
                v.Show();
                this.Visibility = Visibility.Hidden;

            }


        }
    }

    public class TratData
    {
        public string Terapia { get; set; }
        public string Estado { get; set; }
        public string FIni { get; set; }
        public string FFin { get; set; }
    

    }
}
