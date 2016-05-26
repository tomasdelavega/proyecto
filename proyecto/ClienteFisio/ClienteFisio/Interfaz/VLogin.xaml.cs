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


namespace ClienteFisio.Interfaz
{
    /// <summary>
    /// Interaction logic for VLogin.xaml
    /// </summary>
    public partial class VLogin : Window
    {
        public VLogin()
        {
            InitializeComponent();
           
            
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TFisioterapeuta t = ClienteWCF.getServicios().login(txtUsu.Text, txtPass.Password);
                if (t == null)
                    lblAviso.Content = "Usuario inexistente";
                else
                {

                    App.FisioSesion = t;


                    VPrincipal v = new VPrincipal();
                    v.Show();
                    this.Close();
                }
            }
            catch (FaultException<Error> ex)
            {
                lblAviso.Content = ex.Detail.Content;
            }
            catch (FaultException<ErrorSql> ex)
            {
                MessageBox.Show(ex.Detail.Content);
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");
            }
           /* finally
            {
                MessageBox.Show("Fallo en la conexión. El servidor no responde.");
            }
         */
   
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            

           

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            VConfigCon v = new VConfigCon();
            this.IsEnabled = false;
            v.Owner = this;
            v.Show();
            
            
            

        }

        
    }
}
