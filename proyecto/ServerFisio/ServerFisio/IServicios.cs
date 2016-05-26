using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using ServerFisio.DatosDB;
using ServerFisio.DTO;
using ServerFisio.Excepciones;
using System.Net.Mail;

namespace ServerFisio
{
    [ServiceContract]
    public interface IServicios
    {
        [OperationContract]
        String prueba();

        [OperationContract]
        [FaultContract(typeof(Error))]
        void enviarMail(String contenido, String asunto, String ruta, List<String> destinatarios);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        TFisioterapeuta login(String us, String pass);

        /******************PACIENTES***************/
        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void nuevoPaciente(TPaciente p);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void borrarPaciente(String dni);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void modifPaciente(TPaciente p);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TPaciente> recuperarPacientesConMail();

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TPaciente> recuperarPacientes();



        /***********MATERIALES-PEDIDOS*****************/

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TMaterial> recuperarMateriales();

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void borrarMaterial(String nombre);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void añadirMaterial(String nombre);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        void registrarPedido(TPedido pedido);

       

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TPedido> getPedidos();

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        void eliminarPedido(int id);

        /*************FISIOS*******************/

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TFisioterapeuta> recuperarFisios();

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void nuevoFisio(TFisioterapeuta f);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        void eliminarEmp(String dni);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void modifFisio(TFisioterapeuta f);

        /*METODOS TSALA*/

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void nuevaSala(TSala s);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        [FaultContract(typeof(Error))]
        List<TSala> recuperarSalas();

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        [FaultContract(typeof(Error))]
        void eliminarSala(string nombre);

        /*METODOS TDIAGNOSTICO*/

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        [FaultContract(typeof(Error))]
        List<TDiagnostico> recuperarDiagnosticos();

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        void eliminarDiagnostico(int id);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        [FaultContract(typeof(Error))]
        void nuevoDiagnostico(TDiagnostico d);

        /*METODOS TTERAPIA*/

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        [FaultContract(typeof(Error))]
        void nuevaTerapia(TTerapia t);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        [FaultContract(typeof(Error))]
        List<TTerapia> recuperarTerapias();

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        void eliminarTerapia(string nombre);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        void modificarTerapia(TTerapia t);

        /*****************CITAS**************************/

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TSesionCita> getCitas(DateTime date);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        int registrarCita(TSesionCita s);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void borrarCita(int id);

        /****************Historial*******************/
        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<THistorial> recuperarHistoriales(String dni);

        [OperationContract]     
        [FaultContract(typeof(Error))]
       // [FaultContract(typeof(ErrorSql))]
        void registrarNuevoHist(THistorial h);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TTratamiento> recuperarTratamientos(int idHist);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        [FaultContract(typeof(Error))]
        void registrarTratamiento(TTratamiento t,String dni, DateTime fecha);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void cerrarDiagnostico(int id);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void modifDiagnostico(THistorial h);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TSesionCita> recuperarSesionesTrat(int idHist,int idTerap);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void modifTratamiento(TTratamiento t);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void cerrarTratamiento(TTratamiento t);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TTratamiento> getTrataDiagAbiertos(String dni);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        String  getNomDiag(int id);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        String getNomTerap(int id);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        TPaciente getPaciente(String dni);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void modifSesion(TSesionCita s);

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void borrarSesion(int id);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TPedido> getPedidosMes(DateTime d);

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TSesionCita> getSesionesMes(DateTime d);

        /*****comentarios****/

        [OperationContract]
        [FaultContract(typeof(ErrorSql))]
        List<TComentario> getComentarios();

        [OperationContract]
        [FaultContract(typeof(Error))]
        [FaultContract(typeof(ErrorSql))]
        void borrarCom(int id);
     


       


        


    }
}
