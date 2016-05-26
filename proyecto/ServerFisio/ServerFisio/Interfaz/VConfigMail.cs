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
    public partial class VConfigMail : Form
    {
        public VConfigMail()
        {
            InitializeComponent();
            txtSmtp.Text = global::ServerFisio.Properties.Settings.Default.SmtpClient;
            txtPort.Text = Convert.ToString(global::ServerFisio.Properties.Settings.Default.SmtpPort);
            txtUs.Text = global::ServerFisio.Properties.Settings.Default.usuarioMail;
            txtPass.Text = global::ServerFisio.Properties.Settings.Default.passMail;
            if (global::ServerFisio.Properties.Settings.Default.SmtpSecure)
                check.Checked = true;
            else
                check.Checked = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtSmtp.Text == "" || txtPort.Text == "")
            {
                lblStatus.Text = "Faltan campos obligatorios(*)";
            }
            else
            {
                try{
                    global::ServerFisio.Properties.Settings.Default.SmtpPort = Int32.Parse(txtPort.Text);
                    global::ServerFisio.Properties.Settings.Default.SmtpClient = txtSmtp.Text;
                    global::ServerFisio.Properties.Settings.Default.SmtpSecure = check.Checked;
                    global::ServerFisio.Properties.Settings.Default.usuarioMail = txtUs.Text;
                    global::ServerFisio.Properties.Settings.Default.passMail = txtPass.Text;
                    this.Close();
                }
                catch(FormatException ex)
                {
                    lblStatus.Text = "No se permiten caracteres en el puerto";
                }
           
            }



        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VConfigMail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.vPrinc.Enabled = true;
            Program.vPrinc.Show();
        }

       
    }
}
