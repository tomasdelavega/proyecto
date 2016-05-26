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
    /// Interaction logic for VPrecios.xaml
    /// </summary>
    public partial class VConfig : Window
    {
        public VConfig()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox1.Text = ClienteFisio.Properties.Settings.Default.precio.ToString();
            txtAlq.Text = ClienteFisio.Properties.Settings.Default.alquiler.ToString();
            
        }

        private void btnModif_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == "" || txtAlq.Text == "")
            {
                label3.Content = "Rellena los campos.";
            }
            else
            {
                try
                {
                    ClienteFisio.Properties.Settings.Default.alquiler = float.Parse(txtAlq.Text);
                    ClienteFisio.Properties.Settings.Default.precio = float.Parse(textBox1.Text);
                    label3.Content = "Cambios realizados.";
                    this.Close();
                }
                catch (FormatException ex)
                {
                    label3.Content = "Introduce un valor correcto.";
                }


            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Activate();
            this.Owner.IsEnabled = true;

        }
    }
}
