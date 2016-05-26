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
using ClienteFisio.Interfaz.Pacientes;
using ClienteFisio.Interfaz.Mails;

namespace ClienteFisio.Interfaz.Citas
{
    /// <summary>
    /// Interaction logic for VCitas.xaml
    /// </summary>
    public partial class VCitas : Window
    {

        private ObservableCollection<CitaData> _CitasCollection9 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection10 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection11 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection12 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection13 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection16 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection17 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection18 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection19 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection20 = new ObservableCollection<CitaData>();
        private ObservableCollection<CitaData> _CitasCollection21 = new ObservableCollection<CitaData>();
        private ObservableCollection<PacienteData> _PacientesCollection = new ObservableCollection<PacienteData>();
        private List<TSesionCita> listCitasCompleta = new List<TSesionCita>();
        private List<TPaciente> listPacientes = new List<TPaciente>();
        private List<TFisioterapeuta> listFisios = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres9 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres10 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres11 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres12 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres13 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres16 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres17 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres18 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres19 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres20 = new List<TFisioterapeuta>();
        private List<TFisioterapeuta> fLibres21 = new List<TFisioterapeuta>();
        private List<TSala> sLibres9 = new List<TSala>();
        private List<TSala> sLibres10 = new List<TSala>();
        private List<TSala> sLibres11 = new List<TSala>();
        private List<TSala> sLibres12 = new List<TSala>();
        private List<TSala> sLibres13 = new List<TSala>();
        private List<TSala> sLibres16 = new List<TSala>();
        private List<TSala> sLibres17 = new List<TSala>();
        private List<TSala> sLibres18 = new List<TSala>();
        private List<TSala> sLibres19 = new List<TSala>();
        private List<TSala> sLibres20 = new List<TSala>();
        private List<TSala> sLibres21 = new List<TSala>();
        private List<TSala> listSalas = new List<TSala>();
        private List<TSesionCita> listCitas9 = new List<TSesionCita>();
        private List<TSesionCita> listCitas10 = new List<TSesionCita>();
        private List<TSesionCita> listCitas11 = new List<TSesionCita>();
        private List<TSesionCita> listCitas12 = new List<TSesionCita>();
        private List<TSesionCita> listCitas13 = new List<TSesionCita>();
        private List<TSesionCita> listCitas16 = new List<TSesionCita>();
        private List<TSesionCita> listCitas17 = new List<TSesionCita>();
        private List<TSesionCita> listCitas18 = new List<TSesionCita>();
        private List<TSesionCita> listCitas19 = new List<TSesionCita>();
        private List<TSesionCita> listCitas20 = new List<TSesionCita>();
        private List<TSesionCita> listCitas21 = new List<TSesionCita>();
        int confirmacion = 0;
        List<TTratamiento> trataDiagAbiertos = new List<TTratamiento>();
        private DateTime fecha;

        public VCitas(DateTime d)
        {
            InitializeComponent();
            fecha = d;
            lblfecha.Content = d.Day+" de "+getNombreMes(d.Month)+" de "+d.Year; 
          
         
          
        }
        private String getNombreMes(int m)
        {
            String mes = "----";
            switch (m)
            {
                case 1:
                    mes = "Enero";
                    break;
                case 2:
                    mes = "Febrero";
                    break;
                case 3:
                    mes = "Marzo";
                    break;
                case 4:
                    mes = "Abril";
                    break;
                case 5:
                    mes = "Mayo";
                    break;
                case 6:
                    mes = "Junio";
                    break;
                case 7:
                    mes = "Julio";
                    break;
                case 8:
                    mes = "Agosto";
                    break;
                case 9:
                    mes = "Septiembre";
                    break;
                case 10:
                    mes = "Octubre";
                    break;
                case 11:
                    mes = "Noviembre";
                    break;
                case 12:
                    mes = "Diciembre";
                    break;


                 
            }
            return mes;
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Activate();
            this.Owner.IsEnabled = true;
        }

        public ObservableCollection<CitaData> PacientesCollection9
        { get { return _CitasCollection9; } }
        public ObservableCollection<CitaData> PacientesCollection10
        { get { return _CitasCollection10; } }
        public ObservableCollection<CitaData> PacientesCollection11
        { get { return _CitasCollection11; } }
        public ObservableCollection<CitaData> PacientesCollection12
        { get { return _CitasCollection12; } }
        public ObservableCollection<CitaData> PacientesCollection13
        { get { return _CitasCollection13; } }
        public ObservableCollection<CitaData> PacientesCollection16
        { get { return _CitasCollection16; } }
        public ObservableCollection<CitaData> PacientesCollection17
        { get { return _CitasCollection17; } }
        public ObservableCollection<CitaData> PacientesCollection18
        { get { return _CitasCollection18; } }
        public ObservableCollection<CitaData> PacientesCollection19
        { get { return _CitasCollection19; } }
        public ObservableCollection<CitaData> PacientesCollection20
        { get { return _CitasCollection20; } }
        public ObservableCollection<CitaData> PacientesCollection21
        { get { return _CitasCollection21; } }
        public ObservableCollection<PacienteData> PacientesCollection
        { get { return _PacientesCollection; } }
    

        private void calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime d = calendar1.SelectedDate.Value;
            lblfecha.Content = d.Day + " de " + getNombreMes(d.Month) + " de " + d.Year; 
            this.limpiar();
            this.cargar2(d);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            calendar1.DisplayDate = fecha;
            this.cargar1();
            calendar1.SelectedDate = fecha;
            
           // this.cargar2(System.DateTime.Now);
            
        }

        TPaciente getPaciente(String dni)
        {
            TPaciente p = null;
            foreach (TPaciente pa in listPacientes)
                if (pa.Dni == dni)
                    return pa;
            return p;
        }

        TFisioterapeuta getFisio(String dni)
        {
            TFisioterapeuta f = null;
            foreach (TFisioterapeuta fis in listFisios)
            {
                if (fis.Dni == dni)
                    return fis;

            }
            return f;
        }

        TSala getSala(int id)
        {
            TSala s = null;
            foreach (TSala sa in listSalas)
            {
                if (sa.Numero == id)
                    return sa;
            }
            return s;

        }

        TSala getSalaPorNom(String nom)
        {
            TSala s = null;
            foreach (TSala sa in listSalas)
            {
                if (sa.Nombre == nom)
                    return sa;
            }
            return s;

        }

        TFisioterapeuta getFisioPorNom(String nombre)
        {
            TFisioterapeuta f = null;
            foreach (TFisioterapeuta fis in listFisios)
            {
                if (fis.Nombre == nombre)
                    return fis;

            }
            return f;

        }

        private void btnA9_Click(object sender, RoutedEventArgs e)
        {
            if(listViewPac.SelectedIndex != -1 )
            {
                lblAvisosPacientes.Content = "";
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if(disponible(p.Dni))
                {
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 9:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;
                    
                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres9)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres9)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 9;
                    
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }
                                
                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy."; 

                        
            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
            
            
        }

        private void btnA10_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 10:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres10)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres10)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 10;
                  
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";

            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }

        private void btnA11_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 11:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres11)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres11)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 11;
            
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";
            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }

        private void btnA12_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 12:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres12)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres12)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 12;
                
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";

            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }

        private void btnA13_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 13:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres13)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres13)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 13;
                 
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";


            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }

        private void btnA16_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 16:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres16)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres16)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 16;
           
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";

            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }

        private void btnA17_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 17:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres17)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres17)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 17;
                
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";

            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }

        private void btnA18_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 18:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres18)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres18)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 18;
              
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }

                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";

            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }

        private void btnA19_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre+" "+p.Apellidos+" 19:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres19)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres19)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 19;
          
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";

            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }

        private void btnA20_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 20:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres20)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres20)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 20;
                
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";
            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }


        private void btnA21_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPac.SelectedIndex != -1)
            {
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                if (disponible(p.Dni))
                {
                    lblAvisosPacientes.Content = "";
                    lblConfirmTit.Content = p.Nombre + " " + p.Apellidos + " 21:00";
                    gridSelecFisioSala.Visibility = Visibility.Visible;
                    grid1.IsEnabled = false;

                    listViewPac.IsEnabled = false;
                    foreach (TFisioterapeuta f in fLibres21)
                        ComboFisio.Items.Add(f.Nombre);
                    foreach (TSala sa in sLibres21)
                        comboSala.Items.Add(sa.Nombre);
                    if (comboSala.Items.Count > 0)
                        comboSala.SelectedIndex = 0;
                    if (ComboFisio.Items.Count > 0)
                        ComboFisio.SelectedIndex = 0;
                    confirmacion = 21;

           
                    try
                    {
                        comboDiag.Items.Clear();
                        trataDiagAbiertos = ClienteWCF.getServicios().getTrataDiagAbiertos(p.Dni);

                        if (trataDiagAbiertos != null)
                        {

                            foreach (TTratamiento t in trataDiagAbiertos)
                            {
                                String nomD = "***";
                                try
                                {
                                    nomD = ClienteWCF.getServicios().getNomDiag(t.Id_historial);
                                }
                                catch (FaultException<ErrorSql> ex)
                                {
                                    MessageBox.Show(ex.Detail.Content);
                                }
                                catch (EndpointNotFoundException ex)
                                {
                                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                                }

                                comboDiag.Items.Add(nomD);
                            }
                            if (comboDiag.Items.Count > 0)
                                comboDiag.SelectedIndex = 0;
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
                else
                    lblAvisosPacientes.Content = p.Nombre + " ya está citado para hoy.";

            }
            else
                lblAvisosPacientes.Content = "Selecciona un paciente.";
        }

        private void btncomfirmar_Click(object sender, RoutedEventArgs e)
        {
            //if (ComboFisio.SelectedIndex != -1)
           // {
                TSesionCita s = new TSesionCita();
                TPaciente p = listPacientes.ElementAt(listViewPac.SelectedIndex);
                s.Dni_paciente = p.Dni;
                DateTime d;
                if(calendar1.SelectedDate == null)
                    d = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, confirmacion, 0, 0);
                else
                    d = new DateTime(calendar1.SelectedDate.Value.Year, calendar1.SelectedDate.Value.Month, calendar1.SelectedDate.Value.Day, confirmacion, 0, 0);
                s.Fecha = d;
                String fisio = "*****";
                if (ComboFisio.SelectedIndex != -1)
                {
                    TFisioterapeuta f = this.getFisioPorNom(ComboFisio.SelectedItem.ToString());
                    s.Id_fisio = f.Dni;
                    fisio = f.Nombre;
                }
                String sala = "*****";
                if (comboSala.SelectedIndex != -1)
                {
                    TSala sal = this.getSalaPorNom(comboSala.SelectedItem.ToString());
                    s.Id_sala = sal.Numero;
                    sala = sal.Nombre;
                }
                
                    
                s.Pagado = false;
                String pagado = "No";
                s.Precio = ClienteFisio.Properties.Settings.Default.precio;

                if (comboDiag.Items.Count > 0 && trataDiagAbiertos != null)
                {
                    TTratamiento t = trataDiagAbiertos.ElementAt(comboDiag.SelectedIndex);
                    s.Id_historial = t.Id_historial;
                    if(t.Id_terapia != null)
                        s.Id_terapia = t.Id_terapia;
                }

                
                    try
                    {
                        int id = ClienteWCF.getServicios().registrarCita(s);

                        s.Id_cita = id;
                        listCitasCompleta.Add(s);
                        lblAvisos.Content = "";


                        switch (confirmacion)
                        {
                            case 9:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres9.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres9.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                if (fLibres9.Count == 0 || sLibres9.Count == 0)
                                    listV9.Background = Brushes.PaleVioletRed;
                                _CitasCollection9.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala ,Pagado = pagado});
                                listCitas9.Add(s);
                                break;
                            case 10:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres10.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres10.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection10.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres10.Count == 0 || sLibres10.Count == 0)
                                    listV10.Background = Brushes.PaleVioletRed;
                                listCitas10.Add(s);
                                break;
                            case 11:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres11.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres11.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection11.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres11.Count == 0 || sLibres11.Count == 0)
                                    listV11.Background = Brushes.PaleVioletRed;
                                listCitas11.Add(s);
                                break;
                            case 12:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres12.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres12.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection12.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres12.Count == 0 || sLibres12.Count == 0)
                                    listV12.Background = Brushes.PaleVioletRed;
                                listCitas12.Add(s);
                                break;
                            case 13:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres13.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres13.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection13.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres13.Count == 0 || sLibres13.Count == 0)
                                    listV13.Background = Brushes.PaleVioletRed;
                                listCitas13.Add(s);
                                break;
                            case 16:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres16.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres16.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection16.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres16.Count == 0 || sLibres16.Count == 0)
                                    listV16.Background = Brushes.PaleVioletRed;
                                listCitas16.Add(s);
                                break;
                            case 17:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres17.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres17.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection17.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres17.Count == 0 || sLibres17.Count == 0)
                                    listV17.Background = Brushes.PaleVioletRed;
                                listCitas17.Add(s);
                                break;
                            case 18:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres18.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres18.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection18.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres18.Count == 0 || sLibres18.Count == 0)
                                    listV18.Background = Brushes.PaleVioletRed;
                                listCitas18.Add(s);
                                break;
                            case 19:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres19.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres19.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection19.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres19.Count == 0 || sLibres19.Count == 0)
                                    listV19.Background = Brushes.PaleVioletRed;
                                listCitas19.Add(s);
                                break;
                            case 20:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres20.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres20.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection20.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres20.Count == 0 || sLibres20.Count == 0)
                                    listV20.Background = Brushes.PaleVioletRed;
                                listCitas20.Add(s);
                                break;
                            case 21:
                                if (comboSala.SelectedIndex != -1)
                                    sLibres21.Remove(this.getSalaPorNom(comboSala.SelectedItem.ToString()));
                                if (ComboFisio.SelectedIndex != -1)
                                    fLibres21.Remove(this.getFisioPorNom(ComboFisio.SelectedItem.ToString()));
                                _CitasCollection21.Add(new CitaData { Paciente = listPacientes.ElementAt(listViewPac.SelectedIndex).Nombre + " " + listPacientes.ElementAt(listViewPac.SelectedIndex).Apellidos, Fisio = fisio, Sala = sala, Pagado = pagado });
                                if (fLibres21.Count == 0 || sLibres21.Count == 0)
                                    listV21.Background = Brushes.PaleVioletRed;
                                listCitas21.Add(s);
                                break;

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

               
                
          //  }
            gridSelecFisioSala.Visibility = Visibility.Hidden;
            grid1.IsEnabled = true;
            listViewPac.IsEnabled = true;
            ComboFisio.Items.Clear();
            comboSala.Items.Clear();
            listViewPac.SelectedIndex = -1;

        }

        private void llenarFLibres()
        {
            if (listFisios!= null)
            {
                foreach (TFisioterapeuta f in listFisios)
                {
                    if (f.Turno == "M" || f.Turno == "C")
                    {
                        fLibres9.Add(f);
                        fLibres10.Add(f);
                        fLibres11.Add(f);
                        fLibres12.Add(f);
                        fLibres13.Add(f);
                    }
                    if (f.Turno == "T" || f.Turno == "C")
                    {
                        fLibres16.Add(f);
                        fLibres17.Add(f);
                        fLibres18.Add(f);
                        fLibres19.Add(f);
                        fLibres20.Add(f);
                        fLibres21.Add(f);

                    }
                }
            }
        }

        private void llenarSLibres()
        {
            if (listSalas != null)
            {
                foreach (TSala s in listSalas)
                {
                   
                        sLibres9.Add(s);
                        sLibres10.Add(s);
                        sLibres11.Add(s);
                        sLibres12.Add(s);
                        sLibres13.Add(s);
                        sLibres16.Add(s);
                        sLibres17.Add(s);
                        sLibres18.Add(s);
                        sLibres19.Add(s);
                        sLibres20.Add(s);
                        sLibres21.Add(s);

                    
                }
            }
        }

        private void cargar1()
        {
            try
            {
                listFisios = ClienteWCF.getServicios().recuperarFisios();
                if (listFisios == null)
                {
                    listFisios = new List<TFisioterapeuta>();
                    lblAvisosFisios.Content = "No hay fisioterapeutas registrados.";

                }
             
                listSalas = ClienteWCF.getServicios().recuperarSalas();
                if (listSalas == null)
                {
                    listSalas = new List<TSala>();
                    lblAvisosSalas.Content = "No hay citas registradas para el día de hoy.";
                }


                listPacientes = ClienteWCF.getServicios().recuperarPacientes();
                if (listPacientes == null)
                {
                    listPacientes = new List<TPaciente>();
                    lblAvisosPacientes2.Content = "No hay pacientes registrados.";

                }
                else
                {
                    foreach (TPaciente p in listPacientes)
                    {
                        _PacientesCollection.Add(new PacienteData { Apellidos = p.Apellidos, Nombre = p.Nombre, Dni = p.Dni });
                    }
                    listViewPac.SelectedIndex = -1;
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

        public void cargar2(DateTime date)
        {
            try
            {
                
                listCitasCompleta = ClienteWCF.getServicios().getCitas(date);
             
                this.llenarFLibres();
                this.llenarSLibres();
                lblAvisos.Content = "";
                if (listCitasCompleta == null)
                {
                    listCitasCompleta = new List<TSesionCita>();
                    lblAvisos.Content = "No hay citas registradas para el día de hoy.";
                }
                else
                {


                    foreach (TSesionCita s in listCitasCompleta)
                    {

                        String nomSala = "*****";
                        if(s.Id_sala != null)
                            nomSala = this.getSala(int.Parse(Convert.ToString(s.Id_sala))).Nombre;

                        String fisio = "*****";  
                        if(s.Id_fisio != null)
                            fisio = this.getFisio(s.Id_fisio).Nombre;
                        String pagado = "No";
                        if (s.Pagado)
                            pagado = "Si";

                        String nomP = "";
                        String apeP = "";
                        TPaciente p = this.getPaciente(s.Dni_paciente);
                        if (p == null)
                        {
                            nomP = "*Eliminado*";

                        }
                        else
                        {
                            nomP = p.Nombre;
                            apeP = p.Apellidos;
                        }


                        CitaData citD = new CitaData { Paciente = nomP + " " + apeP, Fisio = fisio, Sala = nomSala, Pagado = pagado};
                        switch (s.Fecha.Hour)
                        {
                            case 9:
                                if (s.Id_sala != null)
                                    sLibres9.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres9.Remove(this.getFisio(s.Id_fisio));
                                if (fLibres9.Count == 0 || sLibres9.Count == 0)
                                    listV9.Background = Brushes.PaleVioletRed;
                                listCitas9.Add(s);
                                _CitasCollection9.Add(citD);

                                break;
                            case 10:
                                if (s.Id_sala != null)
                                    sLibres10.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres10.Remove(this.getFisio(s.Id_fisio));
                                if (fLibres10.Count == 0 || sLibres10.Count == 0)
                                    listV10.Background = Brushes.PaleVioletRed;
                                listCitas10.Add(s);
                                _CitasCollection10.Add(citD);

                                break;
                            case 11:
                                if (s.Id_sala != null)
                                    sLibres11.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres11.Remove(this.getFisio(s.Id_fisio));
                                listCitas11.Add(s);
                                if (fLibres11.Count == 0 || sLibres11.Count == 0)
                                    listV11.Background = Brushes.PaleVioletRed;
                                _CitasCollection11.Add(citD);

                                break;
                            case 12:
                                if (s.Id_sala != null)
                                    sLibres12.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres12.Remove(this.getFisio(s.Id_fisio));
                                listCitas12.Add(s);
                                if (fLibres12.Count == 0 || sLibres12.Count == 0)
                                    listV12.Background = Brushes.PaleVioletRed;
                                _CitasCollection12.Add(citD);

                                break;
                            case 13:
                                if (s.Id_sala != null)
                                    sLibres13.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres13.Remove(this.getFisio(s.Id_fisio));
                                listCitas13.Add(s);
                                if (fLibres13.Count == 0 || sLibres13.Count == 0)
                                    listV13.Background = Brushes.PaleVioletRed;
                                _CitasCollection13.Add(citD);

                                break;
                            case 16:
                                if (s.Id_sala != null)
                                    sLibres16.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres16.Remove(this.getFisio(s.Id_fisio));
                                listCitas16.Add(s);
                                if (fLibres16.Count == 0 || sLibres16.Count == 0)
                                    listV16.Background = Brushes.PaleVioletRed;
                                _CitasCollection16.Add(citD);

                                break;
                            case 17:
                                if (s.Id_sala != null)
                                    sLibres17.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres17.Remove(this.getFisio(s.Id_fisio));
                                listCitas17.Add(s);
                                if (fLibres17.Count == 0 || sLibres17.Count == 0)
                                    listV17.Background = Brushes.PaleVioletRed;
                                _CitasCollection17.Add(citD);

                                break;
                            case 18:
                                if (s.Id_sala != null)
                                    sLibres18.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres18.Remove(this.getFisio(s.Id_fisio));
                                listCitas18.Add(s);
                                if (fLibres18.Count == 0 || sLibres18.Count == 0)
                                    listV18.Background = Brushes.PaleVioletRed;
                                _CitasCollection18.Add(citD);

                                break;
                            case 19:
                                if (s.Id_sala != null)
                                    sLibres19.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres19.Remove(this.getFisio(s.Id_fisio));
                                listCitas19.Add(s);
                                if (fLibres19.Count == 0 || sLibres19.Count == 0)
                                    listV19.Background = Brushes.PaleVioletRed;
                                _CitasCollection19.Add(citD);

                                break;
                            case 20:
                                if (s.Id_sala != null)
                                    sLibres20.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres20.Remove(this.getFisio(s.Id_fisio));
                                listCitas20.Add(s);
                                if (fLibres20.Count == 0 || sLibres20.Count == 0)
                                    listV20.Background = Brushes.PaleVioletRed;
                                _CitasCollection20.Add(citD);

                                break;
                            case 21:
                                if (s.Id_sala != null)
                                    sLibres21.Remove(this.getSala(int.Parse(Convert.ToString(s.Id_sala))));
                                if (s.Id_fisio != null)
                                    fLibres21.Remove(this.getFisio(s.Id_fisio));
                                listCitas21.Add(s);
                                if (fLibres21.Count == 0 || sLibres20.Count == 0)
                                    listV21.Background = Brushes.PaleVioletRed;
                                _CitasCollection21.Add(citD);

                                break;
                        }

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

        public void limpiar()
        {
            listV9.Background = Brushes.LightGreen;
            listV10.Background = Brushes.LightGreen;
            listV11.Background = Brushes.LightGreen;
            listV12.Background = Brushes.LightGreen;
            listV13.Background = Brushes.LightGreen;
            listV16.Background = Brushes.LightGreen;
            listV17.Background = Brushes.LightGreen;
            listV18.Background = Brushes.LightGreen;
            listV19.Background = Brushes.LightGreen;
            listV20.Background = Brushes.LightGreen;
            listV21.Background = Brushes.LightGreen;
           


            ComboFisio.Items.Clear();
            comboSala.Items.Clear();          
            fLibres9.Clear();
            fLibres10.Clear();
            fLibres11.Clear();
            fLibres12.Clear();
            fLibres13.Clear();
            fLibres16.Clear();
            fLibres17.Clear();
            fLibres18.Clear();
            fLibres19.Clear();
            fLibres20.Clear();
            fLibres21.Clear();
            sLibres9.Clear();
            sLibres10.Clear();
            sLibres11.Clear();
            sLibres12.Clear();
            sLibres13.Clear();
            sLibres16.Clear();
            sLibres17.Clear();
            sLibres18.Clear();
            sLibres19.Clear();
            sLibres20.Clear();
            sLibres21.Clear();
            _CitasCollection9.Clear();
            _CitasCollection10.Clear();
            _CitasCollection11.Clear();
            _CitasCollection12.Clear();
            _CitasCollection13.Clear();
            _CitasCollection16.Clear();
            _CitasCollection17.Clear();
            _CitasCollection18.Clear();
            _CitasCollection19.Clear();
            _CitasCollection20.Clear();
            _CitasCollection21.Clear();
            listCitas9.Clear();
            listCitas10.Clear();
            listCitas11.Clear();
            listCitas12.Clear();
            listCitas13.Clear();
            listCitas16.Clear();
            listCitas17.Clear();
            listCitas18.Clear();
            listCitas19.Clear();
            listCitas20.Clear();
            listCitas21.Clear();
            listCitasCompleta.Clear();



            

        }

        private void limpiar2()
        {
            listFisios.Clear();
            listSalas.Clear();
            listPacientes.Clear();
            _PacientesCollection.Clear();
        }

        private void btnNoconfirm_Click(object sender, RoutedEventArgs e)
        {
            gridSelecFisioSala.Visibility = Visibility.Hidden;
            grid1.IsEnabled = true;
            listViewPac.IsEnabled = true;
            ComboFisio.Items.Clear();
            comboSala.Items.Clear();
            listViewPac.SelectedIndex = -1;

        }

        bool citado(List<TSesionCita> listaCita, String dniPac)
        {
            bool citado = false;
            foreach (TSesionCita s in listaCita)
                citado = (s.Dni_paciente == dniPac);
            return citado;
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            VAñadirPaciente v = new VAñadirPaciente();
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();
        }

        public void actualizarPacientes()
        {
            try
            {
                _PacientesCollection.Clear();
                listPacientes.Clear();
                listPacientes = ClienteWCF.getServicios().recuperarPacientes();
                if (listPacientes == null)
                {
                    listPacientes = new List<TPaciente>();
                    lblAvisosPacientes2.Content = "No hay pacientes registrados.";

                }
                else
                {
                    foreach (TPaciente p in listPacientes)
                    {
                        _PacientesCollection.Add(new PacienteData { Apellidos = p.Apellidos, Nombre = p.Nombre, Dni = p.Dni });
                    }
                    listViewPac.SelectedIndex = -1;
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

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEmails_Click(object sender, RoutedEventArgs e)
        {
            VMails mail = new VMails();
            this.IsEnabled = false;
            mail.Owner = this;
            mail.Show();
        }

        private void listV9_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV9.SelectedIndex != -1)
            {
                TSesionCita s = listCitas9.ElementAt(listV9.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV9.SelectedIndex = -1;
            }
        }

        private void listV10_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV10.SelectedIndex != -1)
            {
                TSesionCita s = listCitas10.ElementAt(listV10.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV10.SelectedIndex = -1;
            }
        }

        private void listV11_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV11.SelectedIndex != -1)
            {
                TSesionCita s = listCitas11.ElementAt(listV11.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV11.SelectedIndex = -1;
            }
        }

        private void listV12_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV12.SelectedIndex != -1)
            {
                TSesionCita s = listCitas12.ElementAt(listV12.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV12.SelectedIndex = -1;
            }
        }

        private void listV13_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV13.SelectedIndex != -1)
            {
                TSesionCita s = listCitas13.ElementAt(listV13.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV13.SelectedIndex = -1;
            }
        }

        private void listV16_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV16.SelectedIndex != -1)
            {
                TSesionCita s = listCitas16.ElementAt(listV16.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV16.SelectedIndex = -1;
            }
        }

        private void listV17_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV17.SelectedIndex != -1)
            {
                TSesionCita s = listCitas17.ElementAt(listV17.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV17.SelectedIndex = -1;
            }
        }

        private void listV18_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV18.SelectedIndex != -1)
            {
                TSesionCita s = listCitas18.ElementAt(listV18.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV18.SelectedIndex = -1;
            }

        }

        private void listV19_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV19.SelectedIndex != -1)
            {
                TSesionCita s = listCitas19.ElementAt(listV19.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV19.SelectedIndex = -1;
            }
        }

        private void listV20_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV20.SelectedIndex != -1)
            {
                TSesionCita s = listCitas20.ElementAt(listV20.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV20.SelectedIndex = -1;
            }
        }

        private void listV21_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listV21.SelectedIndex != -1)
            {
                TSesionCita s = listCitas21.ElementAt(listV21.SelectedIndex);
                VSesion v = new VSesion(s);
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listV21.SelectedIndex = -1;
            }
        }

        public DateTime getFechaCalendario()
        {
            return calendar1.SelectedDate.Value;
        }

        private bool disponible(string dni)
        {
            foreach (TSesionCita cita in listCitasCompleta)
            {
                if (dni == cita.Dni_paciente)
                    return false;
            }
            return true;
        }

        private void listViewPac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblAvisosPacientes.Content = "";
        }

      /*  private void btnE9_Click(object sender, RoutedEventArgs e)
        {
            if (listV9.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas9.ElementAt(listV9.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas9.ElementAt(listV9.SelectedIndex);
                        fLibres9.Add(this.getFisio(s.Id_fisio));
                        sLibres9.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas9.RemoveAt(listV9.SelectedIndex);
                        _CitasCollection9.RemoveAt(listV9.SelectedIndex);
                        listV9.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);
                        
                    }
                    catch(FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }
        }

        private void btnE10_Click(object sender, RoutedEventArgs e)
        {
            if (listV10.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas10.ElementAt(listV10.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas10.ElementAt(listV10.SelectedIndex);
                        fLibres10.Add(this.getFisio(s.Id_fisio));
                        sLibres10.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas10.RemoveAt(listV10.SelectedIndex);
                        _CitasCollection10.RemoveAt(listV10.SelectedIndex);
                        listV10.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }

        private void btnE11_Click(object sender, RoutedEventArgs e)
        {
            if (listV11.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas11.ElementAt(listV11.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas11.ElementAt(listV11.SelectedIndex);
                        fLibres11.Add(this.getFisio(s.Id_fisio));
                        sLibres11.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas11.RemoveAt(listV11.SelectedIndex);
                        _CitasCollection11.RemoveAt(listV11.SelectedIndex);
                        listV11.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }

        private void btnE12_Click(object sender, RoutedEventArgs e)
        {
            if (listV12.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas12.ElementAt(listV12.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas12.ElementAt(listV12.SelectedIndex);
                        fLibres12.Add(this.getFisio(s.Id_fisio));
                        sLibres12.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas12.RemoveAt(listV12.SelectedIndex);
                        _CitasCollection12.RemoveAt(listV12.SelectedIndex);
                        listV12.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }

        private void btnE13_Click(object sender, RoutedEventArgs e)
        {
            if (listV13.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas13.ElementAt(listV13.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas13.ElementAt(listV13.SelectedIndex);
                        fLibres13.Add(this.getFisio(s.Id_fisio));
                        sLibres13.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas13.RemoveAt(listV13.SelectedIndex);
                        _CitasCollection13.RemoveAt(listV13.SelectedIndex);
                        listV13.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }

        private void btnE16_Click(object sender, RoutedEventArgs e)
        {
            if (listV16.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas16.ElementAt(listV16.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas16.ElementAt(listV16.SelectedIndex);
                        fLibres16.Add(this.getFisio(s.Id_fisio));
                        sLibres16.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas16.RemoveAt(listV16.SelectedIndex);
                        _CitasCollection16.RemoveAt(listV16.SelectedIndex);
                        listV16.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }

        private void btnE17_Click(object sender, RoutedEventArgs e)
        {
            if (listV17.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas17.ElementAt(listV17.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas17.ElementAt(listV17.SelectedIndex);
                        fLibres17.Add(this.getFisio(s.Id_fisio));
                        sLibres17.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas17.RemoveAt(listV17.SelectedIndex);
                        _CitasCollection17.RemoveAt(listV17.SelectedIndex);
                        listV17.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }

        private void btnE18_Click(object sender, RoutedEventArgs e)
        {
            if (listV18.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas18.ElementAt(listV18.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas18.ElementAt(listV18.SelectedIndex);
                        fLibres18.Add(this.getFisio(s.Id_fisio));
                        sLibres18.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas18.RemoveAt(listV18.SelectedIndex);
                        _CitasCollection18.RemoveAt(listV18.SelectedIndex);
                        listV18.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }

        private void btnE19_Click(object sender, RoutedEventArgs e)
        {
            if (listV19.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas19.ElementAt(listV19.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas19.ElementAt(listV19.SelectedIndex);
                        fLibres19.Add(this.getFisio(s.Id_fisio));
                        sLibres19.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas19.RemoveAt(listV19.SelectedIndex);
                        _CitasCollection19.RemoveAt(listV19.SelectedIndex);
                        listV19.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }

        private void btnE20_Click(object sender, RoutedEventArgs e)
        {
            if (listV20.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas20.ElementAt(listV20.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas20.ElementAt(listV20.SelectedIndex);
                        fLibres20.Add(this.getFisio(s.Id_fisio));
                        sLibres20.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas20.RemoveAt(listV20.SelectedIndex);
                        _CitasCollection20.RemoveAt(listV20.SelectedIndex);
                        listV20.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }

        private void btnE21_Click(object sender, RoutedEventArgs e)
        {
            if (listV21.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar la cita?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().borrarCita(listCitas21.ElementAt(listV21.SelectedIndex).Id_cita);
                        TSesionCita s = listCitas21.ElementAt(listV21.SelectedIndex);
                        fLibres21.Add(this.getFisio(s.Id_fisio));
                        sLibres21.Add(this.getSala(int.Parse(s.Id_sala.ToString())));
                        listCitas21.RemoveAt(listV21.SelectedIndex);
                        _CitasCollection21.RemoveAt(listV21.SelectedIndex);
                        listV21.SelectedIndex = -1;


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }


                }
            }

        }*/


    }
    public class CitaData
    {
        public string Paciente { get; set; }
        public string Fisio { get; set; }
        public string Sala { get; set; }
        public string Pagado { get; set; }
    }

    public class PacienteData
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }




}
