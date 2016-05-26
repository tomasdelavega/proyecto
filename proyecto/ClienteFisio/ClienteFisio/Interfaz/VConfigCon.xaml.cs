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

namespace ClienteFisio.Interfaz
{
    /// <summary>
    /// Interaction logic for VConfigCon.xaml
    /// </summary>
    public partial class VConfigCon : Window
    {
        public VConfigCon()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtIp.Text = ClienteFisio.Properties.Settings.Default.ServerFisioIp;
            txtPort.Text = ClienteFisio.Properties.Settings.Default.ServerFisioPort.ToString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Activate();
            this.Owner.IsEnabled = true;

        }

        private void btnaplicar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIp.Text == "" || txtPort.Text == "")
            {
                lbl.Content = "Rellena los campos.";
            }
            else
            {
                try
                {
                    ClienteFisio.Properties.Settings.Default.ServerFisioPort = int.Parse(txtPort.Text);
                    ClienteFisio.Properties.Settings.Default.ServerFisioIp = txtIp.Text;
                    ClienteWCF.recon();
                    lbl.Content = "Cambios realizados.";
                    this.Close();
                }
                catch (FormatException ex)
                {
                    lbl.Content = "Introduce un valor correcto.";
                }


            }
        }
    }
}
