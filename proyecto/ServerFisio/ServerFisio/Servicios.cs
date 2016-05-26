using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ServerFisio.DatosDB;
using ServerFisio.DTO;
using ServerFisio.Excepciones;
using System.Net.Mail;
using System.Data.SqlClient;

namespace ServerFisio
{
    public class Servicios: IServicios
    {
        public String prueba()
        {
            return "Funciona!";
        }
        public void enviarMail(String contenido, String asunto, String ruta, List<String> destinatarios)
        {
            try
            {
                MailSender.enviar(contenido, asunto, ruta, destinatarios);
            }
            catch (SqlException ex)
            {
                Error e = new Error();
                e.Content = "ERROR al acceder a la base de datos, inténtelo de nuevo. Si perdura el error consute con su administrador.";
                throw new FaultException<Error>(e);
            }
            catch (SmtpException ex)
            {
                Error e = new Error();
                e.Content = "ERROR SMTP, intentelo de nuevo. Si perdura el error compruebe la configuración del correo electrónico en el servidor o consulte con su administrador.";
                throw new FaultException<Error>(e);
            }
            
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "No hay pacientes en la base de datos.";
                throw new FaultException<Error>(e);
            }
        }
        public TFisioterapeuta login(String us, String pass)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.login(us, pass);
            }
            catch (InvalidPassException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);

            }
        }

        public void nuevoPaciente(TPaciente p)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.nuevoPaciente(p);
            }
            catch (ErrorDatosExistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);

            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);

            }

        }

        public List<TPaciente> recuperarPacientesConMail()
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.recuperarPacientesConMail();
                   
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public List<TPaciente> recuperarPacientes()
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.recuperarPacientes();

            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public void borrarPaciente(String dni)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.borrarPaciente(dni);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);

            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);

            }

        }

        public void modifPaciente(TPaciente p)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.modifPaciente(p);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);

            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);

            }

        }



        /********************************MATERIALES**************************************************/
        public List<TMaterial> recuperarMateriales()
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getMateriales();
            }

            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public void borrarMaterial(String nombre)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.borrarMaterial(nombre);
            }

            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
            
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "Material no encontrado en la base de datos.";
                throw new FaultException<Error>(e);

            }

        }

        public void añadirMaterial(String nombre)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.añadirMaterial(nombre);
            }

            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosExistentesException ex)
            {
                Error e = new Error();
                e.Content = "'"+nombre+"' ya existe en la base de datos.";
                throw new FaultException<Error>(e);

            }
        }

        public void registrarPedido(TPedido pedido)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {

                dao.registrarPedido(pedido);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }

        }

    

        public List<TPedido> getPedidos()
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getPedidos();
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }

        }

        public void eliminarPedido(int id)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.eliminarPedido(id);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }

        }

        /**********************************FISIOS***************************************/
        public List<TFisioterapeuta> recuperarFisios()
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.recuperarFisios();
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public void nuevoFisio(TFisioterapeuta f)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.nuevoFisio(f);
            }
            catch (ErrorDatosExistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);

            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);

            }
        }

        public void eliminarEmp(String dni)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.eliminarEmp(dni);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }

        }

        public void modifFisio(TFisioterapeuta f)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.modifFisio(f);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);

            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);

            }
        }

        /*METODOS DE EL OBJETO TSALA*/
        public void nuevaSala(TSala s)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.nuevaSala(s);
            }
            catch (ErrorDatosExistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }


        }
        public List<TSala> recuperarSalas()
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return (dao.recuperarSalas());
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public void eliminarSala(string nombre)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.eliminarSala(nombre);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
        }

        /*METODOS TDIAGNOSTICO*/

        public List<TDiagnostico> recuperarDiagnosticos()
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return (dao.recuperarDiagnosticos());
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }
        public void eliminarDiagnostico(int id)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.eliminarDiagnostico(id);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }
        public void nuevoDiagnostico(TDiagnostico d)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.nuevoDiagnostico(d);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = ex.Message;
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosExistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);
            }
        }

        /*METODOS TTERAPIA*/

        public void nuevaTerapia(TTerapia t)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.nuevaTerapia(t);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = ex.Message;
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosExistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);
            }
        }

        public void eliminarTerapia(string nombre)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.eliminarTerapia(nombre);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }
        public List<TTerapia> recuperarTerapias()
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return (dao.recuperarTerapias());
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }
        public void modificarTerapia(TTerapia t)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.modificarTerapia(t);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public List<TSesionCita> getCitas(DateTime date)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getCitas(date);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public int registrarCita(TSesionCita s)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.registrarCita(s);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public void borrarCita(int id)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.borrarCita(id);
            }

            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "Cita no encontrada en la base de datos.";
                throw new FaultException<Error>(e);

            }

        }

        /***************************HISTORIALES***************************/

        public List<THistorial> recuperarHistoriales(String dni)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.recuperarHistoriales(dni);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);
            }
        }

        public void registrarNuevoHist(THistorial h)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.registrarNuevoHist(h);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
           /* catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "No se ha realizado la operación. No se registró una sesión previamente.";
                throw new FaultException<Error>(e);
            }*/
        }

        public List<TTratamiento> recuperarTratamientos(int idHist)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.recuperarTratamientos(idHist);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }

        }

        public void registrarTratamiento(TTratamiento t,String dni, DateTime fecha)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.registrarTratamiento(t,dni,fecha);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosExistentesException ex)
            {
                Error e = new Error();
                e.Content = ex.Message;
                throw new FaultException<Error>(e);
            }
        }

        public void cerrarDiagnostico(int id)
        {
       
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.cerrarDiagnostico(id);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "No  se encuentra el diagnóstico en la BD.";
                throw new FaultException<Error>(e);
            }
        
        }

        public void modifDiagnostico(THistorial h)
        {

            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.modifDiagnostico(h);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "No  se encuentra el diagnóstico en la BD.";
                throw new FaultException<Error>(e);
            }

        }

        public List<TSesionCita> recuperarSesionesTrat(int idHist, int idTerap)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.recuperarSesionesTrat(idHist,idTerap);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }

        }

        public void modifTratamiento(TTratamiento t)
        {
        IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.modifTratamiento(t);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "No  se encuentra el diagnóstico en la BD.";
                throw new FaultException<Error>(e);
            }

        }

        public void cerrarTratamiento(TTratamiento t)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.cerrarTratamiento(t);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "No  se encuentra el diagnóstico en la BD.";
                throw new FaultException<Error>(e);
            }

        }

        public List<TTratamiento> getTrataDiagAbiertos(String dni)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getTrataDiagAbiertos(dni);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }


        }

        public String getNomDiag(int id)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getNomDiag(id);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public String getNomTerap(int id)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getNomTerap(id);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public TPaciente getPaciente(String dni)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getPaciente(dni);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
        }

        public void modifSesion(TSesionCita s)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.modifSesion(s);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "No  se encuentra la sesion en la BD.";
                throw new FaultException<Error>(e);
            }

        }

        public void borrarSesion(int id)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.borrarSesion(id);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "No  se encuentra la sesion en la BD.";
                throw new FaultException<Error>(e);
            }


        }

        public List<TPedido> getPedidosMes(DateTime d)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getPedidosMes(d);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }

        }

        public List<TSesionCita> getSesionesMes(DateTime d)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getSesionesMes(d);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }

        }

        public List<TComentario> getComentarios()
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                return dao.getComentarios();
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }

        }

        public void borrarCom(int id)
        {
            IAccesoDatos dao = AccesoDatos.CreateDao();
            try
            {
                dao.borrarCom(id);
            }
            catch (SqlException ex)
            {
                ErrorSql e = new ErrorSql();
                e.Content = "Error en la conexión con la base de datos, intentelo de nuevo, si perdura el fallo consulte con su administrador.";
                throw new FaultException<ErrorSql>(e);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                Error e = new Error();
                e.Content = "No  se encuentra el comentario en la BD.";
                throw new FaultException<Error>(e);
            }

        }

    }
}
