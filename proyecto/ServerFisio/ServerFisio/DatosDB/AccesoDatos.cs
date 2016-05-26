using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using ServerFisio.DatosDB;
using ServerFisio.Excepciones;
using System.Data.SqlClient;
using ServerFisio.DTO;
//@"Server="+global::ServerFisio.Properties.Settings.Default.SqlServerIP+@"\SQLEXPRESS;Database=FisioDB;Trusted_Connection=True"
namespace ServerFisio.DatosDB
{
    public interface IAccesoDatos
    {
        TFisioterapeuta login(String us, String pass);
        void nuevoPaciente(TPaciente p);
        void borrarPaciente(String dni);
        void modifPaciente(TPaciente p);
        List<TPaciente> recuperarPacientesConMail();
        List<TPaciente> recuperarPacientes();
        List<TMaterial> getMateriales();
        void borrarMaterial(String nombre);
        void añadirMaterial(String nombre);
        void registrarPedido(TPedido pedido);
 
        List<TPedido> getPedidos();
        void eliminarPedido(int id);
        List<TPedido> getPedidosMes(DateTime d);
        List<TFisioterapeuta> recuperarFisios();
        void nuevoFisio(TFisioterapeuta f);
        void eliminarEmp(String dni);
        void modifFisio(TFisioterapeuta f);

        /*Metodos TSala*/
        void nuevaSala(TSala s);
        List<TSala> recuperarSalas();
        void eliminarSala(string nombre);
        /*Metodos Tdiagnostico*/
        List<TDiagnostico> recuperarDiagnosticos();
        void eliminarDiagnostico(int id);
        void nuevoDiagnostico(TDiagnostico d);
        /*Metodos TTerapia*/
        void nuevaTerapia(TTerapia t);
        List<TTerapia> recuperarTerapias();
        void eliminarTerapia(string nombre);
        void modificarTerapia(TTerapia t);
        /***** CITAS ******/
        List<TSesionCita> getCitas(DateTime date);
        int registrarCita(TSesionCita s);
        void borrarCita(int id);
        void borrarSesion(int id);
        List<TSesionCita> getSesionesMes(DateTime d);
        


        /****************HISTORIALES***********/

        List<THistorial> recuperarHistoriales(String dni);
        void registrarNuevoHist(THistorial h);
        List<TTratamiento> recuperarTratamientos(int idHist);
        void registrarTratamiento(TTratamiento t,String dni, DateTime fecha);
        void cerrarDiagnostico(int id);
        void modifDiagnostico(THistorial h);
        List<TSesionCita> recuperarSesionesTrat(int idHist, int idTerap);
        void modifTratamiento(TTratamiento t);
        void cerrarTratamiento(TTratamiento t);
        List<TTratamiento> getTrataDiagAbiertos(String dni);
        String getNomDiag(int id);
        String getNomTerap(int id);
        TPaciente getPaciente(String dni);
        void modifSesion(TSesionCita s);
        /*****comentarios*****/
        List<TComentario> getComentarios();
        void borrarCom(int id);
        
    }
    public class AccesoDatos:IAccesoDatos
    {
        private static AccesoDatos yo;
        private AccesoDatos() { }
        public static AccesoDatos CreateDao()
        {
            if (yo == null)
                yo = new AccesoDatos();
            return yo;
        }
        public TFisioterapeuta login(String us, String pass)
        {
            TFisioterapeuta t = null;
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();

                var fisios = (from fisio in dc.TFisioterapeuta where fisio.Usuario == us select fisio);
                if (fisios.Count() > 0)
                {
                    if (fisios.First().Pass == pass)
                    {
                        t = fisios.First();
                        return t;
                    }
                    else throw new InvalidPassException();
                }
               
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return null;
        }

        public void nuevoPaciente(TPaciente p)
        {
         
            
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();

                var pacientes = from paciente in dc.TPaciente where paciente.Dni == p.Dni select paciente;
                if (pacientes.Count() > 0)
                    throw new ErrorDatosExistentesException("El paciente que se desea insertar ya existe");
                dc.TPaciente.InsertOnSubmit(p);
                dc.SubmitChanges();
 
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public void borrarPaciente(String dni)
        {


            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();

                var pacientes = from paciente in dc.TPaciente where paciente.Dni == dni select paciente;
                if (pacientes.Count() == 0)
                    throw new ErrorDatosInexistentesException("El paciente no existe.");
                dc.TPaciente.DeleteOnSubmit(pacientes.First());
                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public void modifPaciente(TPaciente p)
        {


            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();

                var pacientes = from paciente in dc.TPaciente where paciente.Dni == p.Dni select paciente;
                if (pacientes.Count() == 0)
                    throw new ErrorDatosInexistentesException("El paciente no existe.");
                TPaciente pac = pacientes.First();
                pac.Nombre = p.Nombre;
                pac.Apellidos = p.Apellidos;
                pac.Email = p.Email;
                pac.F_nac = p.F_nac;
                pac.Sexo = p.Sexo;
                pac.Tfno1 = p.Tfno1;
                pac.Tfno2 = p.Tfno2;
                pac.Observs = p.Observs;

                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public List<TPaciente> recuperarPacientesConMail()
        {
            List<TPaciente> listPac = null;
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var pacientes = from paciente in dc.TPaciente orderby paciente.Apellidos select paciente;
                if (pacientes.Count() > 0)
                {
                    listPac = new List<TPaciente>();
                    foreach (TPaciente p in pacientes)
                    {
                        if (p.Email != "")
                            listPac.Add(p);
                    }
                }
                return listPac;
                    
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public List<TPaciente> recuperarPacientes()
        {
            List<TPaciente> listPac = null;
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var pacientes = from paciente in dc.TPaciente orderby paciente.Apellidos select paciente;
                if (pacientes.Count() > 0)
                {
                    listPac = pacientes.ToList();
                }
                return listPac;

            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        /********************MATERIALES*****************/
        public List<TMaterial> getMateriales()
        {
            List<TMaterial> listMat = null;
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var materiales = from material in dc.TMaterial orderby material.Nombre select material;
                if (materiales.Count() > 0)
                {
                    listMat = new List<TMaterial>(); ;
                    foreach (TMaterial mat in materiales)
                        listMat.Add(mat);
                }
                return listMat;

            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public void borrarMaterial(String nombre)
        {

            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var materiales = from material in dc.TMaterial where material.Nombre == nombre select material;
                if (materiales.Count() > 0)
                  
                    dc.TMaterial.DeleteOnSubmit(materiales.First());
                else
                    throw new ErrorDatosInexistentesException();

                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
          
        }

        public void añadirMaterial(String nombre)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var materiales = from material in dc.TMaterial where material.Nombre == nombre select material;
                if (materiales.Count() > 0)
                    throw new ErrorDatosExistentesException();
                else
                {
                    TMaterial m = new TMaterial();
                    m.Nombre = nombre;
                    dc.TMaterial.InsertOnSubmit(m);
                }
                    

                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ErrorDatosExistentesException ex)
            {
                throw ex;
            }
        }

        public void registrarPedido(TPedido pedido)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                foreach (TLineaPedidos l in pedido.TLineaPedidos)
                {
                    var materiales = from material in dc.TMaterial where material.Id_material == l.Id_material select material;
                    l.TMaterial = materiales.First();
                }

              
                dc.TPedido.InsertOnSubmit(pedido);

                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        

        public List<TPedido> getPedidos()
        {
            List<TPedido> pedidosR = null;
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                DataLoadOptions options = new DataLoadOptions();
                options.LoadWith<TPedido>(p => p.TLineaPedidos);
                dc.LoadOptions = options;
                var pedidos = from pedido in dc.TPedido orderby pedido.Fecha descending select pedido;
                if (pedidos.Count() > 0)
                    pedidosR = pedidos.ToList();

                return pedidosR;

            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }


        public void eliminarPedido(int id)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var pedidos = from pedido in dc.TPedido where pedido.Id_pedido == id select pedido;
                dc.TPedido.DeleteOnSubmit(pedidos.First());
                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        /***************FISIOS*****************************/
        public List<TFisioterapeuta> recuperarFisios()
        {
            List<TFisioterapeuta> listFR = null;
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var fisios = from fisio in dc.TFisioterapeuta select fisio;
                if (fisios.Count() > 0)
                    listFR = fisios.ToList<TFisioterapeuta>();
                return listFR;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

           
        }

        public void nuevoFisio(TFisioterapeuta f)
        {

            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var fisios = from fisio in dc.TFisioterapeuta where fisio.Dni == f.Dni select fisio;
               
                if (fisios.Count() > 0)
                    throw new ErrorDatosExistentesException("Este empleado ya existe.");
                dc.TFisioterapeuta.InsertOnSubmit(f);
                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public void eliminarEmp(String dni)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var emps = from emp in dc.TFisioterapeuta where emp.Dni == dni select emp;
                dc.TFisioterapeuta.DeleteOnSubmit(emps.First());
                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public void modifFisio(TFisioterapeuta f)
        {

            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var fisios = from fisio in dc.TFisioterapeuta where fisio.Dni == f.Dni select fisio;

                if (fisios.Count() == 0)
                    throw new ErrorDatosInexistentesException("El empleado "+f.Dni+" no existe.");

                TFisioterapeuta fisModif = fisios.First();
                fisModif.Nombre = f.Nombre;
                fisModif.Apellidos = f.Apellidos;
                fisModif.Derechos = f.Derechos;
                fisModif.Email = f.Email;
                fisModif.Num_colegiado = f.Num_colegiado;
                fisModif.Pass = f.Pass;
                fisModif.Salario = f.Salario;
                fisModif.Tfno = f.Tfno;
                fisModif.Tfno2 = f.Tfno2;
                fisModif.Turno = f.Turno;
                fisModif.Usuario = f.Usuario;
                
                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }


        /*METODOS TSALA*/

        public void nuevaSala(TSala s)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                int existe = (from sala in dc.TSala where sala.Nombre == s.Nombre select sala).Count();
                if (existe != 0)
                    throw new ErrorDatosExistentesException("El nombre de la sala ya existe");
                dc.TSala.InsertOnSubmit(s);
                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (ErrorDatosExistentesException ex)
            {
                throw (ex);
            }
        }

        public List<TSala> recuperarSalas()
        {
            List<TSala> listaSalas = null;
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var salas = (from sal in dc.TSala orderby sal.Nombre select sal);
                if (salas.Count() > 0)
                {
                    listaSalas = salas.ToList<TSala>();
                }
                return (listaSalas);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void eliminarSala(string nombre)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var salaExistente = (from sala in dc.TSala where sala.Nombre == nombre select sala).First();
                dc.TSala.DeleteOnSubmit(salaExistente);
                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }
        /*METODOS DIAGNOSTICO*/
        public List<TDiagnostico> recuperarDiagnosticos()
        {
            List<TDiagnostico> ldiag = null;
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var diagnosticos = (from diag in dc.TDiagnostico orderby diag.Nombre select diag);
                if (diagnosticos.Count() > 0)
                {
                    ldiag = diagnosticos.ToList<TDiagnostico>();
                }
                return (ldiag);
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }
        public void eliminarDiagnostico(int id)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var diagnosticoExistente = (from diag in dc.TDiagnostico where diag.Id == id select diag).First();
                dc.TDiagnostico.DeleteOnSubmit(diagnosticoExistente);
                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }
        public void nuevoDiagnostico(TDiagnostico d)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();

                var diagnosticos = (from diag in dc.TDiagnostico where diag.Nombre == d.Nombre select diag);
                if (diagnosticos.Count() > 0)
                    throw new ErrorDatosExistentesException("El diagnóstico ya existe");
                dc.TDiagnostico.InsertOnSubmit(d);
                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        /*METODOS TTERAPIA*/
        public void nuevaTerapia(TTerapia t)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var terapia = (from tera in dc.TTerapia where tera.Nombre == t.Nombre select tera);
                if (terapia.Count() > 0)
                    throw new ErrorDatosExistentesException("La terapia ya existe");
                dc.TTerapia.InsertOnSubmit(t);
                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<TTerapia> recuperarTerapias()
        {
            List<TTerapia> lTerapias = null;
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var terapias = (from tera in dc.TTerapia orderby tera.Nombre select tera);
                if (terapias.Count() > 0)
                    lTerapias = terapias.ToList<TTerapia>();
                return (lTerapias);
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }
        public void eliminarTerapia(string nombre)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var terapiaExistente = (from tera in dc.TTerapia where tera.Nombre == nombre select tera).First();
                dc.TTerapia.DeleteOnSubmit(terapiaExistente);
                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }
        public void modificarTerapia(TTerapia t)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var terapiaExistente = (from tera in dc.TTerapia where tera.Nombre == t.Nombre select tera).First();
                if (terapiaExistente != null)
                {
                    terapiaExistente.Numsesiones = t.Numsesiones;
                    terapiaExistente.Descripcion = t.Descripcion;
                    terapiaExistente.Imagen = t.Imagen;
                    dc.SubmitChanges();
                }

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }
        /***********************CITAS*************************/
        public List<TSesionCita> getCitas(DateTime date)
        {
            List<TSesionCita> listCitas = null;
            
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
            

                var citas = from cita in dc.TSesionCita where cita.Fecha.Day == date.Day && cita.Fecha.Month == date.Month && cita.Fecha.Year == date.Year select cita;
                if (citas.Count() > 0)
                    listCitas = citas.ToList();
                return listCitas;    

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public int registrarCita(TSesionCita s)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                dc.TSesionCita.InsertOnSubmit(s);
                dc.SubmitChanges();
                return s.Id_cita;

            }
            catch (SqlException ex)
            {
                throw (ex);
            }

        }

        public void borrarCita(int id)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var citas = from cita in dc.TSesionCita where cita.Id_cita == id select cita;
                if (citas.Count() > 0)
                    dc.TSesionCita.DeleteOnSubmit(citas.First());


                else
                    throw new ErrorDatosInexistentesException();

                dc.SubmitChanges();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
        }

        /********************Historiales**************/////////

        public List<THistorial> recuperarHistoriales(String dni)
        {
         

            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();


                var historiales = from historial in dc.THistorial where historial.Dni_paciente == dni orderby historial.F_inicio ascending select historial;
                if (historiales.Count() > 0)
                    return historiales.ToList();
                return null;

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public void registrarNuevoHist(THistorial h)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                /*var sesiones = from sesion in dc.TSesionCita where sesion.Dni_paciente == h.Dni_paciente && sesion.Id_historial == null && sesion.Id_terapia == null && sesion.Fecha.Day == System.DateTime.Now.Day && sesion.Fecha.Month == System.DateTime.Now.Month && sesion.Fecha.Year == System.DateTime.Now.Year && sesion.Fecha.Hour == System.DateTime.Now.Hour select sesion;
                if (sesiones.Count() == 0)
                    throw new ErrorDatosInexistentesException();
                TSesionCita s = sesiones.First();
                s.Id_historial = h.Id;*/
   
                dc.THistorial.InsertOnSubmit(h);
                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
          /*  catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }*/

        }

        public List<TTratamiento> recuperarTratamientos(int idHist)
        {
           

            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();


                var tratamientos = from tratamiento in dc.TTratamiento where tratamiento.Id_historial == idHist orderby tratamiento.F_inicio ascending select tratamiento;
                if (tratamientos.Count() > 0)
                    return tratamientos.ToList();

                return null;

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public void registrarTratamiento(TTratamiento t,String dni,DateTime fecha)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var sesiones = from sesion in dc.TSesionCita where sesion.Dni_paciente == dni && sesion.Fecha.Day == fecha.Day && sesion.Fecha.Month == fecha.Month && sesion.Fecha.Year == fecha.Year select sesion;
                if (sesiones.Count() == 0)
                    throw new ErrorDatosExistentesException("No se ha realizado la operación. No se registró una sesión previamente.¿Quieres hacerlo ahora?");

                var tratamientos = from tratamiento in dc.TTratamiento where tratamiento.Id_historial == t.Id_historial && tratamiento.Id_terapia == t.Id_terapia select tratamiento;
                if (tratamientos.Count() > 0)
                    throw new ErrorDatosExistentesException("Ya se ha aplicado esta terapia a este diagnóstico.");

                TSesionCita s = sesiones.First();
                if(s.Id_terapia == 0 || s.Id_terapia == null)
                    s.Id_terapia = t.Id_terapia;
                if(s.Id_historial == 0 || s.Id_historial == null)
                    s.Id_historial = t.Id_historial;
                var historiales = from historial in dc.THistorial where historial.Id == t.Id_historial select historial;
                if (historiales.Count() > 0)
                {
                    THistorial h = historiales.First();
                    if (t.F_inicio.Year < h.F_inicio.Year)
                        h.F_inicio = t.F_inicio;
                    else if (t.F_inicio.Year == h.F_inicio.Year)
                    {
                        if(t.F_inicio.Month < h.F_inicio.Month)
                            h.F_inicio = t.F_inicio;
                        else if (t.F_inicio.Month == h.F_inicio.Month)
                        {
                            if(t.F_inicio.Day < h.F_inicio.Day)
                                h.F_inicio = t.F_inicio;
                        }
                    }

                }
                
                dc.TTratamiento.InsertOnSubmit(t);

                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (ErrorDatosExistentesException ex)
            {
                throw ex;
            }

        }

        public void cerrarDiagnostico(int id)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();


                var historiales = from historial in dc.THistorial where historial.Id == id select historial;
                if (historiales.Count() == 0)
                    throw new ErrorDatosInexistentesException();
                THistorial t = historiales.First();
                t.F_fin = System.DateTime.Now;
                t.Estado = "Cerrado";
                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
        }

        public void modifDiagnostico(THistorial h)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();


                var historiales = from historial in dc.THistorial where historial.Id == h.Id select historial;
                if (historiales.Count() == 0)
                    throw new ErrorDatosInexistentesException();
                THistorial t = historiales.First();
                t.Observaciones = h.Observaciones;
                t.Zona = h.Zona;
                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
        }

        public List<TSesionCita> recuperarSesionesTrat(int idHist, int idTerap)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var sesiones = from sesion in dc.TSesionCita where sesion.Id_historial == idHist && sesion.Id_terapia == idTerap orderby sesion.Fecha ascending select sesion;
                if (sesiones.Count() > 0)
                    return sesiones.ToList();
                return null;    

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public void modifTratamiento(TTratamiento t)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();


                var tratamientos = from tratamiento in dc.TTratamiento where tratamiento.Id_historial == t.Id_historial && tratamiento.Id_terapia == t.Id_terapia select tratamiento;
                if(tratamientos.Count() == 0)
                    throw new ErrorDatosInexistentesException();
                TTratamiento tra = tratamientos.First();
                tra.Observaciones = t.Observaciones;
             
                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
        }

        public void cerrarTratamiento(TTratamiento t)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();


                var tratamientos = from tratamiento in dc.TTratamiento where tratamiento.Id_historial == t.Id_historial && tratamiento.Id_terapia == t.Id_terapia select tratamiento;
                if (tratamientos.Count() == 0)
                    throw new ErrorDatosInexistentesException();
                TTratamiento tra = tratamientos.First();
                tra.Estado = t.Estado;
                tra.F_fin = t.F_fin;

                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
        }

        public List<TTratamiento> getTrataDiagAbiertos(String dni)
        {
            try
            {
                List<TTratamiento> listR = null;
                FisioDBDataContext dc = new FisioDBDataContext();
                var historiales = from historial in dc.THistorial where historial.Dni_paciente == dni && historial.Estado == "Abierto" select historial;
                if (historiales.Count() > 0)
                {
                    listR = new List<TTratamiento>();
                    foreach (THistorial h in historiales)
                    {
                        var tratamientos = from trata in dc.TTratamiento where trata.Id_historial == h.Id && trata.Estado == "Abierto" select trata;
                        if (tratamientos.Count() > 0)
                            listR.Add(tratamientos.First());
                        else
                        {
                            TTratamiento trat = new TTratamiento();
                            trat.Id_historial = h.Id;
                            listR.Add(trat);
                        }
                    }
                }

                return listR;
                

            }
            catch (SqlException ex)
            {
                throw (ex);
            }

        }

        public String getNomDiag(int id)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                var hists = from hist in dc.THistorial where hist.Id == id select hist;
                if (hists.Count() > 0)
                {
                    var diags = from diag in dc.TDiagnostico where diag.Id == hists.First().Id_diagnostico select diag;
                    if (diags.Count() > 0)
                        return diags.First().Nombre;
                }

                return "***";

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public String getNomTerap(int id)
        {
            try
            {
                String nom = null;
                FisioDBDataContext dc = new FisioDBDataContext();
                var terapias = from terap in dc.TTerapia where terap.Id == id select terap;
                if (terapias.Count() > 0)
                    return terapias.First().Nombre;

                return nom;

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public TPaciente getPaciente(String dni)
        {
            try
            {
                TPaciente pR = null;
                FisioDBDataContext dc = new FisioDBDataContext();
                var pacientes = from paciente in dc.TPaciente where paciente.Dni == dni select paciente;
                if (pacientes.Count() > 0)
                    return pacientes.First();
                return pR;

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public void modifSesion(TSesionCita s)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();


                var sesions = from sesion in dc.TSesionCita where sesion.Id_cita == s.Id_cita select sesion;
                if (sesions.Count() == 0)
                    throw new ErrorDatosInexistentesException();
                TSesionCita se = sesions.First();
                se.Observaciones = s.Observaciones;
                se.Fecha = s.Fecha;
                se.Pagado = s.Pagado;
                se.Precio = s.Precio;

                    

                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
        }

        public void borrarSesion(int id)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();


                var sesions = from sesion in dc.TSesionCita where sesion.Id_cita == id select sesion;
                if (sesions.Count() == 0)
                    throw new ErrorDatosInexistentesException();
                dc.TSesionCita.DeleteOnSubmit(sesions.First());



                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }

        }

        public List<TPedido> getPedidosMes(DateTime d)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();
                DataLoadOptions options = new DataLoadOptions();
                options.LoadWith<TPedido>(p => p.TLineaPedidos);
                dc.LoadOptions = options;

                var pedidos = from pedido in dc.TPedido where pedido.Fecha.Year == d.Year && pedido.Fecha.Month == d.Month orderby pedido.Fecha select pedido;
                if (pedidos.Count() > 0)
                    return pedidos.ToList();

                return null;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public List<TSesionCita> getSesionesMes(DateTime d)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();

                var sesiones = from sesion in dc.TSesionCita where sesion.Fecha.Year == d.Year && sesion.Fecha.Month == d.Month orderby sesion.Dni_paciente select sesion;
                if (sesiones.Count() > 0)
                    return sesiones.ToList();

                return null;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
        }

        public List<TComentario> getComentarios()
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();

                var comentarios = from comentario in dc.TComentario orderby comentario.Fecha descending select comentario;
                if (comentarios.Count() > 0)
                    return comentarios.ToList();


                return null;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }

        }

        public void borrarCom(int id)
        {
            try
            {
                FisioDBDataContext dc = new FisioDBDataContext();


                var comentarios = from comentario in dc.TComentario where comentario.Id == id select comentario;
                if (comentarios.Count() == 0)
                    throw new ErrorDatosInexistentesException();
                dc.TComentario.DeleteOnSubmit(comentarios.First());

                dc.SubmitChanges();

            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            catch (ErrorDatosInexistentesException ex)
            {
                throw ex;
            }
        }
    }
}
