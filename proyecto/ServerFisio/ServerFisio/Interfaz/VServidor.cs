using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace ServerFisio.Interfaz
{
    public partial class VServidor : Form
    {
        private ServiceHost hos;
        public VServidor()
        {
            InitializeComponent();

           
            this.iniciar();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.iniciar();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            this.detener();
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.iniciar();
        }
        private void detenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.detener();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.detener();
            Application.Exit();
        }

        private void iniciar()
        {
            Uri uri = new Uri("http://localhost:" + global::ServerFisio.Properties.Settings.Default.puerto + "/ServerFisio");
            hos = new ServiceHost(typeof(Servicios),uri);
           
          

            try
            {

                hos.Open();
                lblStatus.Text = "Servidor funcionando en puerto " + Properties.Settings.Default.puerto;
                btnIniciar.Enabled = false;
                btnDetener.Enabled = true;
                iniciarToolStripMenuItem.Enabled = false;
                detenerToolStripMenuItem.Enabled = true;
                notifyIcon1.Text = "Servidor funcionando en puerto " + Properties.Settings.Default.puerto;
                

            }

            catch (Exception ex)
            {

                lblStatus.Text = "ERROR: " + ex.Message;

            }
        }

        private void detener()
        {
            try
            {
                hos.Close();
                lblStatus.Text = "Servidor detenido";
                btnIniciar.Enabled = true;
                btnDetener.Enabled = false;
                iniciarToolStripMenuItem.Enabled = true;
                detenerToolStripMenuItem.Enabled = false;
                notifyIcon1.Text = "Servidor detenido";

            }

            catch (Exception ex)
            {
                lblStatus.Text = "ERROR: " + ex.Message;

            }
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void serverFisioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new VConfig().Show();

        }

        private void sqlServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new VConfigSql().Show();

        }

        private void eMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new VConfigMail().Show();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void VServidor_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon1.Visible = true;
            }
        }

    

 

        
    }
}
