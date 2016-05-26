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

namespace ClienteFisio.Interfaz.Pacientes
{
    /// <summary>
    
    /// </summary>
    public partial class VModifPaciente : Window
    {
        public TPaciente paciente;
        public VModifPaciente(TPaciente p)
        {
            paciente = p;
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            lblAvisos.Content = "";
            if (txtNombre.Text == ""  || txtApellidos.Text == "")
                lblAvisos.Content = "Hay campos obligatorios sin completar(*)";
            else
            {
                try
                {
                    TPaciente p = new TPaciente();
                    if(txtTfno.Text != "")
                        p.Tfno1 = Int32.Parse(txtTfno.Text);
                    if(txtMovil.Text != "")
                        p.Tfno2 = Int32.Parse(txtMovil.Text);

                    p.Dni = txtDni.Text;
                    p.Nombre = txtNombre.Text;
                    p.Apellidos = txtApellidos.Text;
                    if (comboGenero.SelectedIndex == 0)
                        p.Sexo = "V";
                    else if (comboGenero.SelectedIndex == 1)
                        p.Sexo = "M";
                    p.Email = txtEmail.Text;
                    p.Observs = txtObs.Text;
                    p.F_nac = datePicker1.SelectedDate;
                    try
                    {
                        ClienteWCF.getServicios().modifPaciente(p);
                        ((VPacientes)this.Owner).limpiarLista();
                        ((VPacientes)this.Owner).cargarLista();

                      
                        this.Close();
                  
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
                    lblAvisos.Content = "Introduce correctamente el tfno";
                }
                
            }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtDni.Text = paciente.Dni;
            txtNombre.Text = paciente.Nombre;
            txtApellidos.Text = paciente.Apellidos;
            txtTfno.Text = Convert.ToString(paciente.Tfno1);
            txtMovil.Text = Convert.ToString(paciente.Tfno2);
            txtEmail.Text = paciente.Email;
            txtObs.Text = paciente.Observs; 
            datePicker1.SelectedDate = paciente.F_nac;
            if (paciente.Sexo == "V")
                comboGenero.SelectedIndex = 0;
            else if (paciente.Sexo == "M")
                comboGenero.SelectedIndex = 1;
        
        }

      
        
    }
}
