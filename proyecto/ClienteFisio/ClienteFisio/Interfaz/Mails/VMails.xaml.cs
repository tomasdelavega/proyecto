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
using Microsoft.Win32;
//using System.Net.Mail;

namespace ClienteFisio.Interfaz.Mails
{
    /// <summary>
    /// Interaction logic for Mails.xaml
    /// </summary>
    public partial class VMails : Window
    {
        
        public VMails()
        {
            InitializeComponent();
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Activate();
            this.Owner.IsEnabled = true;
        }

        

        private void radioTodos_Checked(object sender, RoutedEventArgs e)
        {
            this.canvasDestinatarios.IsEnabled = false;
        }

        private void radioElegirDest_Checked(object sender, RoutedEventArgs e)
        {
            this.canvasDestinatarios.IsEnabled = true;
            comboDest.Items.Clear();
            try
            {
                List<TPaciente> pacientes = ClienteWCF.getServicios().recuperarPacientesConMail();
                if (pacientes == null)
                    MessageBox.Show("No hay pacientes en la base de datos");
                else
                {
                    foreach (TPaciente p in pacientes)
                    {
                        comboDest.Items.Add(p.Apellidos + " " + p.Nombre + " : " + p.Email);
                    }
                    if(comboDest.Items.Count > 0)
                        comboDest.SelectedIndex = 0;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            radioTodos.IsChecked = true;


        }

       

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if(!listDestinatarios.Items.Contains(comboDest.SelectedItem))
                listDestinatarios.Items.Add(comboDest.SelectedItem.ToString());
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (((listDestinatarios.Items.Count > 0) && radioElegirDest.IsChecked.Value) || radioTodos.IsChecked.Value)
            {
                lblAvisos.Content = "";
                List<String> destinatarios = null;
                if (radioElegirDest.IsChecked == true)
                {
                    destinatarios = new List<String>();
                    char[] delimitador = { ':' };
                    for (int i = 0; i < listDestinatarios.Items.Count; i++)
                    {
                        String[] separado = listDestinatarios.Items.GetItemAt(i).ToString().Split(delimitador);
                        destinatarios.Add(separado[1]);
                    }
                }
                try
                {
                    ClienteWCF.getServicios().enviarMail(txtConte.Text, txtAsunto.Text, textBoxRuta.Text, destinatarios);
                    this.Close();
                }
                catch (FaultException<Error> ex)
                {
                    MessageBox.Show(ex.Detail.Content);
                }
                catch (EndpointNotFoundException ex)
                {
                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                }
            }
            else
                lblAvisos.Content = "No hay contactos seleccionados.";

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if(listDestinatarios.SelectedIndex != -1)
                listDestinatarios.Items.RemoveAt(listDestinatarios.SelectedIndex);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdjuntar_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fichero = new OpenFileDialog();
            fichero.ShowDialog();
            textBoxRuta.Text = fichero.FileName;
        }

       
    }
}
