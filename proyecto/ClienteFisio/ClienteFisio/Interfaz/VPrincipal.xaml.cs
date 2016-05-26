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
using ClienteFisio.Interfaz.Pacientes;
using ClienteFisio.Interfaz.Mails;
using ClienteFisio.Interfaz.Materiales;
using ClienteFisio.Interfaz.Empleados;
using ClienteFisio.Interfaz.Diagnosticos;
using ClienteFisio.Interfaz.Terapias;
using ClienteFisio.Interfaz.Salas;
using ClienteFisio.Interfaz.Citas;
using ClienteFisio.ClientWCF;

namespace ClienteFisio.Interfaz
{
    /// <summary>
    /// Interaction logic for VPrincipal.xaml
    /// </summary>
    public partial class VPrincipal : Window
    {
        public VPrincipal()
        {
           
            InitializeComponent();
          // = new ServiciosClient("BasicHttpBinding_IMiServicio", "http://" + ClienteFisio.Properties.Settings.Default.ServerFisioIp + ":" + ClienteFisio.Properties.Settings.Default.ServerFisioPort + "/BlogWCF/Servicio");
          
       
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.Title = App.FisioSesion.Nombre + " " + App.FisioSesion.Apellidos + " Nº " + App.FisioSesion.Num_colegiado;

            if (App.FisioSesion.Derechos != "administrador")
            {
                btnCitas.IsEnabled = false;
                btnCuentas.IsEnabled = false;
                btnEmpleados.IsEnabled = false;
                btnMails.IsEnabled = false;
                btnPedidos.IsEnabled = false;
                menu1.IsEnabled = false;

            }

        }

        private void btnPacientes_Click(object sender, RoutedEventArgs e)
        {
            VPacientes pac = new VPacientes();
            pac.Owner = this;
            pac.Show();
            this.Visibility = Visibility.Hidden;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            VMails mail = new VMails();
            this.IsEnabled = false;
            mail.Owner = this;
            mail.Show();

            
        }

        private void btnMateriales_Click(object sender, RoutedEventArgs e)
        {
            VMateriales vm = new VMateriales();
            this.IsEnabled = false;
            vm.Owner = this;
            vm.Show();
        }

        private void btnPedidos_Click(object sender, RoutedEventArgs e)
        {
            VPedidos vp = new VPedidos();
            this.IsEnabled = true;
            vp.Owner = this;
            vp.Show();
        }

        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            VFisios vf = new VFisios();
            vf.Owner = this;
            this.IsEnabled = false;
            vf.Show();
            
        }

        private void btnSalas_Click(object sender, RoutedEventArgs e)
        {
            VSalas vs = new VSalas();
            vs.Owner = this;
            this.IsEnabled = false;
            vs.Show();
        }

        private void btnTerapias_Click(object sender, RoutedEventArgs e)
        {
            VTerapias v = new VTerapias();
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();

        }

        private void btnDiagnosticos_Click(object sender, RoutedEventArgs e)
        {
            Vdiagnosticos v = new Vdiagnosticos();
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();


        }

        private void btnCitas_Click(object sender, RoutedEventArgs e)
        {
            VCitas v = new VCitas(System.DateTime.Now);
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();

        }

       
       

        private void itemRegPeds_Click(object sender, RoutedEventArgs e)
        {
            VPedidos vp = new VPedidos();
            this.IsEnabled = true;
            vp.Owner = this;
            vp.Show();
          

        }
        private void itemNPaciente_Click(object sender, RoutedEventArgs e)
        {
            VAñadirPaciente pac = new VAñadirPaciente();
            this.IsEnabled = false;
            pac.Owner = this;
            pac.Show();


        }
        private void itemHist_Click(object sender, RoutedEventArgs e)
        {
            VPacientes pac = new VPacientes();
            pac.Owner = this;
            pac.Show();
            this.Visibility = Visibility.Hidden;


        }
        private void itemCit_Click(object sender, RoutedEventArgs e)
        {
            VCitas v = new VCitas(System.DateTime.Now);
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();


        }

        private void itemEmail_Click(object sender, RoutedEventArgs e)
        {
            VMails mail = new VMails();
            this.IsEnabled = false;
            mail.Owner = this;
            mail.Show();


        }

        private void itemMat_Click(object sender, RoutedEventArgs e)
        {
            VMateriales vm = new VMateriales();
            this.IsEnabled = false;
            vm.Owner = this;
            vm.Show();


        }

    

        private void itemSalas_Click(object sender, RoutedEventArgs e)
        {
            VSalas vs = new VSalas();
            vs.Owner = this;
            this.IsEnabled = false;
            vs.Show();


        }
        private void itemEmps_Click(object sender, RoutedEventArgs e)
        {
            VFisios vf = new VFisios();
            vf.Owner = this;
            this.IsEnabled = false;
            vf.Show();


        }
        private void itemDiags_Click(object sender, RoutedEventArgs e)
        {
            Vdiagnosticos v = new Vdiagnosticos();
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();


        }
        private void itemTeraps_Click(object sender, RoutedEventArgs e)
        {
            VTerapias v = new VTerapias();
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();


        }
        private void itemApli_Click(object sender, RoutedEventArgs e)
        {
       


        }
        private void itemOtros_Click(object sender, RoutedEventArgs e)
        {
            VConfig v = new VConfig();
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();
           

        }

        private void itemCon_Click(object sender, RoutedEventArgs e)
        {
            VConfigCon v = new VConfigCon();
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();


        }

        private void btnsalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r = MessageBox.Show("¿Quieres salir de la aplicación?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (r == MessageBoxResult.Yes)
            {
                this.Close();

            }
        }

        private void btnCuentas_Click(object sender, RoutedEventArgs e)
        {
            VCuentas v = new VCuentas();
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            VComentarios v = new VComentarios();
            v.Owner = this;
            this.IsEnabled = false;
            v.Show();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            VLogin v = new VLogin();
            v.Show();
            this.Close();

        }



       

       
    }
}
