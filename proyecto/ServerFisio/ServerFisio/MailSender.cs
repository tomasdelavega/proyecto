using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using ServerFisio.DatosDB;
using System.Data.SqlClient;
using ServerFisio.Excepciones;
using System.ServiceModel;


namespace ServerFisio
{
    public class MailSender
    {
        public static void enviar(String contenido, String asunto, String ruta, List<String> destinatarios)
        {
            MailMessage msgMail = new MailMessage();

            try
            {
                
                if (destinatarios == null)// envio a todos
                {
                    IAccesoDatos dao = AccesoDatos.CreateDao();
                    List<TPaciente> pacientes = null;
                    try
                    {
                        pacientes = dao.recuperarPacientesConMail();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    
                    if (pacientes == null)
                        throw new ErrorDatosInexistentesException();
                    foreach (TPaciente p in pacientes)
                    {
                        msgMail.To.Add(new MailAddress(p.Email));
                    }
                }
                else// envio a los que pasamos como parametro
                {
                    foreach (String d in destinatarios)
                    {
                        msgMail.To.Add(new MailAddress(d));
                    }
                }




                msgMail.From = new MailAddress(global::ServerFisio.Properties.Settings.Default.usuarioMail);

                msgMail.Subject = asunto;

                msgMail.Body = contenido;

                if (ruta != "")
                    msgMail.Attachments.Add(new Attachment(ruta));

                SmtpClient clienteSmtp = new SmtpClient(global::ServerFisio.Properties.Settings.Default.SmtpClient);
                clienteSmtp.Port = global::ServerFisio.Properties.Settings.Default.SmtpPort;
                clienteSmtp.EnableSsl = global::ServerFisio.Properties.Settings.Default.SmtpSecure;

                clienteSmtp.Credentials = new NetworkCredential(global::ServerFisio.Properties.Settings.Default.usuarioMail, global::ServerFisio.Properties.Settings.Default.passMail);




                clienteSmtp.Send(msgMail);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
               
                throw ex;
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
             
            

        }
        
    }
}
