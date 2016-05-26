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
using ClienteFisio.Interfaz.Diagnosticos;

namespace ClienteFisio.Interfaz.Pacientes
{
    /// <summary>
    /// Interaction logic for VNuevoHist.xaml
    /// </summary>
   
    public partial class VNuevoHist : Window
    {
        private List<TDiagnostico> listDiagnosticos;
        private TPaciente paciente;
        //private ObservableCollection<DiagData> _DiagCollection = new ObservableCollection<DiagData>();
        public VNuevoHist(TPaciente p)
        {
            InitializeComponent();
       
            paciente = p;
        }
       /* public ObservableCollection<DiagData> DiagCollection
        { get { return _DiagCollection; } }*/

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Activate();
            this.Owner.IsEnabled = true;
        }

        private void btnvolver_Click(object sender, RoutedEventArgs e)
        {
     
            this.Close();
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            Vdiagnosticos v = new Vdiagnosticos();
            v.Owner = this;
            this.IsEnabled = false;
            v.bloquearElim();
            v.Show();
            
        }

        public void actualizar()
        {
            listDiagnosticos.Clear();
            comboBox1.Items.Clear();
          
                try
                {
                    listDiagnosticos = ClienteWCF.getServicios().recuperarDiagnosticos();
                    if (listDiagnosticos == null)
                    {
                        lblAviso.Content = "No hay diagnósticos en la base de datos.";
                        listDiagnosticos = new List<TDiagnostico>();
                    }
                    else
                        foreach (TDiagnostico d in listDiagnosticos)
                            comboBox1.Items.Add(d.Nombre);
                   
                    
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                listDiagnosticos = ClienteWCF.getServicios().recuperarDiagnosticos();
                if (listDiagnosticos == null)
                {
                    lblAviso.Content = "No hay diagnósticos en la base de datos.";
                    listDiagnosticos = new List<TDiagnostico>();
                }
                else
                    foreach (TDiagnostico d in listDiagnosticos)
                        comboBox1.Items.Add(d.Nombre);


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
            lblTit.Content = paciente.Nombre+" " +paciente.Apellidos+" "+System.DateTime.Now.ToShortDateString()  ;
         
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                THistorial h = new THistorial();
                h.Dni_paciente = paciente.Dni;
                h.Estado = "Abierto";
                h.F_inicio = System.DateTime.Now;
                h.Id_diagnostico = listDiagnosticos.ElementAt(comboBox1.SelectedIndex).Id;
                h.Zona = textBox1.Text;
                h.Observaciones = textBox2.Text;
                try
                {
                    ClienteWCF.getServicios().registrarNuevoHist(h);
                    ((VPacientes)this.Owner).actualizarDiagnosticos();
                    ((VPacientes)this.Owner).actualizarHistorial();
                    
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
               

            }
            else
                lblAviso.Content = "Selecciona un diagnóstico.";
        }
    }
  /*  public class DiagData
    {   
        public string Nombre { get; set; }
    }*/
    
}
