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
    /// Interaction logic for VPacientes.xaml
    /// </summary>
    public partial class VPacientes : Window
    {
        private List<TPaciente> listPacientes;
        private List<THistorial> listHistoriales;
        private List<TDiagnostico> listDiagnosticos = new List<TDiagnostico>();
        private ObservableCollection<PacienteData> _PacientesCollection = new ObservableCollection<PacienteData>();
        private ObservableCollection<HistData> _HistCollection = new ObservableCollection<HistData>();
        public VPacientes()
        {
            InitializeComponent();
           
        }

        public ObservableCollection<PacienteData> PacientesCollection
        { get { return _PacientesCollection; } }
        public ObservableCollection<HistData> HistCollection
        { get { return _HistCollection; } }

        private void btnAñadirPac_Click(object sender, RoutedEventArgs e)
        {
            VAñadirPaciente pac = new VAñadirPaciente();
            this.IsEnabled = false;
            pac.Owner = this;
            pac.Show();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
         
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Show();
            this.Owner.Activate();
            this.Owner.IsEnabled = true;
    

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                listPacientes = ClienteWCF.getServicios().recuperarPacientes();
                if (listPacientes == null)
                {
                    listPacientes = new List<TPaciente>();
                    lblAvisos.Content = "No hay pacientes en la base de datos.";
                }
                else
                {
                    foreach (TPaciente p in listPacientes)
                    {
                        _PacientesCollection.Add(new PacienteData { Apellidos = p.Apellidos, Nombre = p.Nombre, Dni = p.Dni });
                    }
                }
                this.actualizarDiagnosticos();

                

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

            if (listViewPac.Items.Count > 0)
                listViewPac.SelectedIndex = 0;
        }

        private void listViewPac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblAvisos2.Content = "";
            _HistCollection.Clear();
            if (listViewPac.SelectedIndex != -1)
            {
                
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if(p.Tfno1 != null)
                    lblTfno2.Content = Convert.ToString(p.Tfno1);
                if (p.Tfno2 != null)
                    lblMovil2.Content = Convert.ToString(p.Tfno2);
                lblEmail2.Content = p.Email;
                lblfe2.Content = p.F_nac.Value.ToShortDateString();
                txtObsPaciente.Text = p.Observs;
                lblHistTit.Content = "Historial de "+p.Nombre+" "+p.Apellidos;
                try
                {
                   listHistoriales =  ClienteWCF.getServicios().recuperarHistoriales(p.Dni);
                   if (listHistoriales == null)
                   {
                       listHistoriales = new List<THistorial>();
                       lblAvisos2.Content = "No hay historiales para " + p.Nombre + " " + p.Apellidos + ".";
                   }
                   else
                   {
                       foreach (THistorial h in listHistoriales)
                       {
                           String fecha = "";
                           if(h.F_fin != null)
                               fecha = h.F_fin.Value.ToShortDateString();
                           TDiagnostico d = this.getDiagnostico(h.Id_diagnostico);
                           String nomDiagnos = "*Eliminado*";
                           if (d != null)
                               nomDiagnos = d.Nombre;
                           _HistCollection.Add(new HistData { Diagnostico = nomDiagnos, FInicio = h.F_inicio.ToShortDateString(), Estado = h.Estado , Zona = h.Zona, FFin =  fecha});
                       }
                   }
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

       

        private void listViewPac_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
       
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                MessageBoxResult r = MessageBox.Show("¿Seguro que deseas eliminar al paciente "+p.Dni+"?","",MessageBoxButton.YesNo,MessageBoxImage.Exclamation);
                if (r == MessageBoxResult.Yes)
                {

                    try
                    {
                        ClienteWCF.getServicios().borrarPaciente(p.Dni);
                        listPacientes.RemoveAt(listViewPac.SelectedIndex);
                        _PacientesCollection.RemoveAt(listViewPac.SelectedIndex);

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


        }

        public void limpiarLista()
        {
            _PacientesCollection.Clear();
        }

        public void cargarLista()
        {
            try
            {
                listPacientes = ClienteWCF.getServicios().recuperarPacientes();
                if (listPacientes == null)
                {
                    listPacientes = new List<TPaciente>();
                    lblAvisos.Content = "No hay pacientes en la base de datos.";
                }
                else
                {
                    foreach (TPaciente p in listPacientes)
                    {
                        _PacientesCollection.Add(new PacienteData { Apellidos = p.Apellidos, Nombre = p.Nombre, Dni = p.Dni });
                    }
                    if (listViewPac.Items.Count > 0)
                        listViewPac.SelectedIndex = 0;
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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if(listViewPac.SelectedIndex !=-1)
            {
                VModifPaciente vmp = new VModifPaciente(listPacientes.ElementAt(listViewPac.SelectedIndex));
                vmp.Owner = this;
                this.IsEnabled = false;
                vmp.Show();
            }
        }

        private void btnAgregarHist_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                VNuevoHist v = new VNuevoHist(listPacientes.ElementAt(listViewPac.SelectedIndex));
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
            }
        }

        private TDiagnostico getDiagnostico(int id)
        {
            TDiagnostico dR = null;
            foreach (TDiagnostico d in listDiagnosticos)
                if (d.Id == id)
                    return d;
            return dR;
        }

        public void actualizarHistoriales(THistorial h)
        {
            listHistoriales.Add(h);
            String fecha = "";
            if (h.F_fin != null)
                fecha = h.F_fin.Value.ToShortDateString();
            TDiagnostico d = this.getDiagnostico(h.Id_diagnostico);
            String nomDiagnos = "*Eliminado*";
            if (d != null)
                nomDiagnos = d.Nombre;
            _HistCollection.Add(new HistData { Diagnostico = nomDiagnos, Zona = h.Zona, Estado = h.Estado, FInicio = h.F_inicio.ToShortDateString(), FFin = fecha});

        }

        public void actualizarDiagnosticos()
        {
          
           

            try
            {
                listDiagnosticos = ClienteWCF.getServicios().recuperarDiagnosticos();
                if (listDiagnosticos == null)
                {

                    lblAvisos2.Content = "No hay diagnósticos en la base de datos.";
                    listDiagnosticos = new List<TDiagnostico>();
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

        private void listViewHist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewHist.SelectedIndex != -1)
            {
                THistorial h = listHistoriales.ElementAt(listViewHist.SelectedIndex);
                TDiagnostico d = this.getDiagnostico(h.Id_diagnostico);
                String nomD = "*Eliminado*";
                if (d != null)
                    nomD = d.Nombre;
                VHistorial v = new VHistorial(h, this.getPaciente(h.Dni_paciente),nomD);
                v.Owner = this;
            
                
                v.Show();
                this.Visibility = Visibility.Hidden;
            }
            
        }

        private void listViewHist_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            

        }

        private TPaciente getPaciente(String dni)
        {
            TPaciente pR = null;
            foreach (TPaciente p in listPacientes)
                if (p.Dni == dni)
                    return p;
            return pR;
        }

        public void setIndexM1()
        {
            listViewHist.SelectedIndex = -1;

        }

        public void actualizarHistorial()
        {
            lblAvisos2.Content = "";
            _HistCollection.Clear();
            TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
          /*  if (p.Tfno1 != null)
                lblTfno2.Content = Convert.ToString(p.Tfno1);
            if (p.Tfno2 != null)
                lblMovil2.Content = Convert.ToString(p.Tfno2);
            lblEmail2.Content = p.Email;
            lblfe2.Content = p.F_nac.Value.ToShortDateString();
            txtObsPaciente.Text = p.Observs;
            lblHistTit.Content = "Historial de " + p.Nombre + " " + p.Apellidos;*/
            try
            {
                listHistoriales = ClienteWCF.getServicios().recuperarHistoriales(p.Dni);
                if (listHistoriales == null)
                {
                    listHistoriales = new List<THistorial>();
                    lblAvisos2.Content = "No hay historiales para " + p.Nombre + " " + p.Apellidos + ".";
                }
                else
                {
                    foreach (THistorial h in listHistoriales)
                    {
                        String fecha = "";
                        if (h.F_fin != null)
                            fecha = h.F_fin.Value.ToShortDateString();
                        TDiagnostico d = this.getDiagnostico(h.Id_diagnostico);
                        String nomDiagnos = "*Eliminado*";
                        if (d != null)
                            nomDiagnos = d.Nombre;
                        _HistCollection.Add(new HistData { Diagnostico = nomDiagnos, FInicio = h.F_inicio.ToShortDateString(), Estado = h.Estado, Zona = h.Zona, FFin = fecha });
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

        
    }

    public class PacienteData
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }

    public class HistData
    {
        public string Diagnostico { get; set; }
        public string FInicio { get; set; }
        public string FFin { get; set; }
        public string Estado { get; set; }
        public string Zona { get; set; }
       
    }
}
