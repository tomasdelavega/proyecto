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
using System.Collections.ObjectModel;

namespace ClienteFisio.Interfaz.Empleados
{
    /// <summary>
    /// Interaction logic for AñadirPaciente.xaml
    /// </summary>
    /// 

    public partial class VFisios : Window
    {
        private List<TFisioterapeuta> listFisios = new List<TFisioterapeuta>();
        ObservableCollection<EmpData> _EmpCollection = new ObservableCollection<EmpData>();
        public VFisios()
        {
            InitializeComponent();
           
            comboDerechos.Items.Add("administrador");
            comboDerechos.Items.Add("usuario");
            comboDerechos.SelectedIndex = 1;
           

        }

        public ObservableCollection<EmpData> EmpCollection
        { get { return _EmpCollection; } }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.IsEnabled = true;
            this.Owner.Activate();

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            lblAvisos.Content = "";
            lblAvisios2.Content = "";
            if (txtDni.Text == "" || txtNombre.Text == ""  || txtApellidos.Text == "" || txtNumCol.Text=="" || txtus.Text == "" || txtPass.Password == "" || txtSalario.Text == "" )
                lblAvisos.Content = "Hay campos obligatorios sin completar(*)";
            else
            {
                try
                {
                    TFisioterapeuta p = new TFisioterapeuta();
                    if(txtTfno.Text != "")
                        p.Tfno = Int32.Parse(txtTfno.Text);
                    if(txtMovil.Text != "")
                        p.Tfno2 = Int32.Parse(txtMovil.Text);

                    p.Salario = float.Parse(txtSalario.Text);

                    p.Dni = txtDni.Text;
                    p.Nombre = txtNombre.Text;
                    p.Apellidos = txtApellidos.Text;
                    p.Num_colegiado = txtNumCol.Text;
                    p.Usuario = txtus.Text;
                    p.Pass = txtPass.Password;
                    p.Derechos = comboDerechos.SelectedItem.ToString();
                    p.Email = txtEmail.Text;
                    if(rCompleta.IsChecked == true)
                        p.Turno = "C";
                    else if(rMañana.IsChecked == true)
                        p.Turno = "M";
                    else 
                        p.Turno = "T";
                    
                    try
                    {
                        ClienteWCF.getServicios().nuevoFisio(p);
                        listFisios.Add(p);
                        _EmpCollection.Add(new EmpData { Dni = p.Dni, Nombre = p.Nombre, Apellidos = p.Apellidos });
                        lblAvisos.Content = p.Nombre+ " " + p.Apellidos + " registrado satisfactoriamente.";
                       
                  
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
                catch (FormatException ex)
                {
                    lblAvisos.Content = "¿Has introducido correctamente el telefono y/o el salario?";
                }
                
            }

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.cargar();
            


        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (listVFisios.SelectedIndex != -1)
            {
                TFisioterapeuta f = listFisios.ElementAt(listVFisios.SelectedIndex);
                MessageBoxResult r = MessageBox.Show("¿Está seguro de que desea borrar al empleado " + f.Nombre + " " + f.Apellidos + "?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {

                        ClienteWCF.getServicios().eliminarEmp(f.Dni);
                        listFisios.RemoveAt(listVFisios.SelectedIndex);
                        _EmpCollection.RemoveAt(listVFisios.SelectedIndex);
                        //listVFisios.Items.RemoveAt(listVFisios.SelectedIndex);
                        lblAvisos.Content = f.Nombre+" "+f.Apellidos+"  borrado.";

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

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            lblAvisos.Content = "";
            lblAvisios2.Content = "";
            if (txtDni.Text == "" || txtNombre.Text == "" || txtApellidos.Text == "" || txtNumCol.Text == "" || txtus.Text == "" || txtPass.Password == "" || txtSalario.Text == "")
                lblAvisos.Content = "Hay campos obligatorios sin completar(*)";
            else
            {
                try
                {
                    TFisioterapeuta p = new TFisioterapeuta();
                    if (txtTfno.Text != "")
                        p.Tfno = Int32.Parse(txtTfno.Text);
                    if (txtMovil.Text != "")
                        p.Tfno2 = Int32.Parse(txtMovil.Text);

                    p.Salario = float.Parse(txtSalario.Text);

                    p.Dni = txtDni.Text;
                    p.Nombre = txtNombre.Text;
                    p.Apellidos = txtApellidos.Text;
                    p.Num_colegiado = txtNumCol.Text;
                    p.Usuario = txtus.Text;
                    p.Pass = txtPass.Password;
                    p.Derechos = comboDerechos.SelectedItem.ToString();
                    p.Email = txtEmail.Text;
                    if (rCompleta.IsChecked == true)
                        p.Turno = "C";
                    else if (rMañana.IsChecked == true)
                        p.Turno = "M";
                    else
                        p.Turno = "T";

                    try
                    {
                        ClienteWCF.getServicios().modifFisio(p);
       
                        lblAvisos.Content = p.Nombre + " " + p.Apellidos + " modificado satisfactoriamente.";
                        listVFisios.SelectedIndex = -1;
                        /****borrado de la tabla***/
                        //ObservableCollection<EmpData> emps = (ObservableCollection < EmpData >) listVFisios.ItemsSource;
                        if (_EmpCollection != null)
                        {
                            _EmpCollection.Clear();
                        }
                        this.cargar();



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
                catch (FormatException ex)
                {
                    lblAvisos.Content = "¿Has introducido correctamente el telefono y/o el salario?";
                }

            }

        }

        private void cargar()
        {
            try
            {
                listFisios = ClienteWCF.getServicios().recuperarFisios();
                if (listFisios == null)
                {
                    lblAvisios2.Content = "No hay empleados.";
                    listFisios = new List<TFisioterapeuta>();
                }
                else
                {
                    foreach (TFisioterapeuta f in listFisios)
                        _EmpCollection.Add(new EmpData {Dni = f.Dni,Nombre = f.Nombre, Apellidos = f.Apellidos });
                       



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

        private void listVFisios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listVFisios.SelectedIndex != -1)
            {
                TFisioterapeuta f = listFisios.ElementAt(listVFisios.SelectedIndex);
                txtDni.Text = f.Dni;
                txtApellidos.Text = f.Apellidos;
                 comboDerechos.SelectedItem = f.Derechos;
                txtDni.Text = f.Dni;
                txtEmail.Text= f.Email;
                txtNombre.Text= f.Nombre;
                txtPass.Password = f.Pass;
                txtSalario.Text= Convert.ToString(f.Salario);
                if(f.Tfno != null)
                    txtTfno.Text = Convert.ToString(f.Tfno);
                if(f.Tfno2 != null)
                    txtMovil.Text = Convert.ToString(f.Tfno2);
                if (f.Turno == "C")
                    rCompleta.IsChecked = true;
                else if(f.Turno =="M")
                    rMañana.IsChecked  = true;
                else
                    rTarde.IsChecked = true;
                txtus.Text = f.Usuario;
                txtNumCol.Text = f.Num_colegiado;
                
            }
        }

       
    }

    public class EmpData
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
