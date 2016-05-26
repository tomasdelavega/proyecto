using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerFisio.Interfaz
{
    public partial class VConfig : Form
    {
        public VConfig()
        {
            InitializeComponent();
            txtPuerto.Text = global::ServerFisio.Properties.Settings.Default.puerto.Trim();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String puertoActual = global::ServerFisio.Properties.Settings.Default.puerto.Trim();
            String puertoNuevo = txtPuerto.Text.Trim();
            try
            {  
                int.Parse(puertoNuevo);
                bool iguales = (puertoActual == puertoNuevo);
                if (!iguales)
                {
                    global::ServerFisio.Properties.Settings.Default.puerto = puertoNuevo;
                    MessageBox.Show("El puerto se utilizará cuando se inicie de nuevo el servidor");
                }
                Program.vPrinc.Enabled = true;
                this.Close();
            }
            catch (FormatException ex)
            {
                lblStatus.Text = "Solo se admiten dígitos";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.vPrinc.Enabled = true;
            Program.vPrinc.Show();
            this.Close();

        }

        private void VConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.vPrinc.Enabled = true;
            Program.vPrinc.Show();
        }

    }
}
