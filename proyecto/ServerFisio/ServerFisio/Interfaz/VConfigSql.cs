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
    public partial class VConfigSql : Form
    {
        public VConfigSql()
        {
            InitializeComponent();
            txtIp.Text = global::ServerFisio.Properties.Settings.Default.SqlServerIP;
            
        }

       

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Program.vPrinc.Enabled = true;
            Program.vPrinc.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtIp.Text != "")
            {
               
                    global::ServerFisio.Properties.Settings.Default.SqlServerIP = txtIp.Text;
                    Program.vPrinc.Enabled = true;
                    this.Close();
                
               
            }
            else
                lblAviso.Text = "Campo vacios";
        }

        private void VConfigSql_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.vPrinc.Enabled = true;
            Program.vPrinc.Show();
        }

       

      

    
    }
}
