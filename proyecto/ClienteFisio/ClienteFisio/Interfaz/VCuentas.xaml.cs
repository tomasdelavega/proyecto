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
using ClienteFisio.ClientWCF;
using System.ServiceModel;
using System.Collections.ObjectModel;
using ClienteFisio.Interfaz.Pacientes;

namespace ClienteFisio.Interfaz
{
    /// <summary>
    /// Interaction logic for VCuentas.xaml
    /// </summary>
    public partial class VCuentas : Window
    {
        private List<TFisioterapeuta> listF = new List<TFisioterapeuta>();
        private List<TSesionCita> listS = new List<TSesionCita>();
        private List<TPedido> listp = new List<TPedido>();
        ObservableCollection<EData> _EmpCollection = new ObservableCollection<EData>();
        ObservableCollection<PData> _PedidosCollection = new ObservableCollection<PData>();
        ObservableCollection<SData> _SCollection = new ObservableCollection<SData>();
        private int numPedidos;
        private float impTotPedidos, totSalarios, totCobradas, totNoCobradas, gastosTo, ingresosTot, results, otrosGast;
        public VCuentas()
        {
            InitializeComponent();
        }

        public ObservableCollection<EData> EmpCollection
        { get { return _EmpCollection; } }
        public ObservableCollection<PData> PedidosCollection
        { get { return _PedidosCollection; } }
        public ObservableCollection<SData> SCollection
        { get { return _SCollection; } }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.Activate();
            this.Owner.IsEnabled = true;


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            calendar1.SelectedDate = System.DateTime.Now;
        }

        public void cargar()
        {
            try
            {
                lblIngresos.Content = "";
                lblGastos.Content = "";
                lblResult.Content = "";
                lblTotSalarios.Content = "";
                lblSesCobradas.Content = "";
                lblSesNoCobradas.Content = "";
                lblNPedidos.Content = "";
                lblImpTotPedidos.Content = "";
                _SCollection.Clear();
                _PedidosCollection.Clear();
                _EmpCollection.Clear();
                gastosTo = 0;
                ingresosTot = 0;
                results = 0;
                otrosGast = 0;
                label9.Content = "Resultados de " + this.getNombreMes(calendar1.SelectedDate.Value.Month) + " de "+calendar1.SelectedDate.Value.Year;
                listF = ClienteWCF.getServicios().recuperarFisios();
                if (listF == null)
                {
                    lblAvisosE.Content = "No hay empleados en la base de datos.";
                    listF = new List<TFisioterapeuta>();
                }
                else
                {
                    totSalarios = 0;
                    foreach (TFisioterapeuta f in listF)
                    {
                        totSalarios += float.Parse(f.Salario.ToString());
                        _EmpCollection.Add(new EData { Empleado = f.Apellidos + " " + f.Nombre, Salario = f.Salario.ToString() });
                    }
                    lblTotSalarios.Content = totSalarios + " €";
                    gastosTo += totSalarios;
                }

                listp = ClienteWCF.getServicios().getPedidosMes(calendar1.SelectedDate.Value);
                if (listp == null)
                {
                    lblAvisosP.Content = "No hay pedidos para este mes.";
                    listp = new List<TPedido>();
                }
                else
                {
                    impTotPedidos = 0;
                    numPedidos = 0;
                    float total = 0;
                    foreach (TPedido p in listp)
                    {
                        numPedidos++;
                        total = 0;
                        foreach (TLineaPedidos lin in p.TLineaPedidos)
                        {
                            total += float.Parse(lin.Precio.ToString()) * lin.Cantidad;
             
                        }
                        impTotPedidos += total;
                        _PedidosCollection.Add(new PData { Fecha = p.Fecha.ToShortDateString(), Id = p.Id_pedido.ToString(), Total = total.ToString() });
                    }

                    lblNPedidos.Content = numPedidos;
                    lblImpTotPedidos.Content = impTotPedidos + " €";
                    gastosTo += impTotPedidos;

                }

                listS = ClienteWCF.getServicios().getSesionesMes(calendar1.SelectedDate.Value);
                if (listS == null)
                {
                    lblAvisosS.Content = "No hay sesiones registradas en este mes.";
                    listS = new List<TSesionCita>();
                }
                else
                {
                    totCobradas = 0;
                    totNoCobradas = 0;
                    foreach (TSesionCita f in listS)
                    {
                        String pagado = "No";
                        if (f.Pagado)
                        {
                            totCobradas += float.Parse(f.Precio.ToString());
                            pagado = "Si";
                        }
                        else
                            totNoCobradas += float.Parse(f.Precio.ToString());

                        _SCollection.Add(new SData { Paciente = f.Dni_paciente, Pagado = pagado, Importe = f.Precio.ToString() });
                    }

                    lblSesCobradas.Content = totCobradas + " €";
                    lblSesNoCobradas.Content = totNoCobradas + " €";
                    ingresosTot += totCobradas;
                }

                gastosTo += ClienteFisio.Properties.Settings.Default.alquiler;
                results = ingresosTot - gastosTo;
                lblIngresos.Content = ingresosTot + " €";
                lblGastos.Content = gastosTo + " €";
                lblResult.Content = results + " €";



            }
            catch (FaultException<ErrorSql> ex)
            {
                MessageBox.Show(ex.Detail.Content);
                this.Close();
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");
                this.Close();
            }
        }

       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                otrosGast = float.Parse(textBox1.Text);
                
                lblResult.Content = (results - otrosGast) + " €";

            }
            catch (FormatException ex)
            {
                lblResult.Content = results  + " €";
            }


        }

        private void listViewS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewS.SelectedIndex != -1)
            {
                VSesion v = new VSesion(listS.ElementAt(listViewS.SelectedIndex));
                v.Owner = this;
                this.IsEnabled = false;
                v.Show();
                listViewS.SelectedIndex = -1;
            }
        }

        private void calendar1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            this.cargar();
        }
        private String getNombreMes(int m)
        {
            String mes = "----";
            switch (m)
            {
                case 1:
                    mes = "Enero";
                    break;
                case 2:
                    mes = "Febrero";
                    break;
                case 3:
                    mes = "Marzo";
                    break;
                case 4:
                    mes = "Abril";
                    break;
                case 5:
                    mes = "Mayo";
                    break;
                case 6:
                    mes = "Junio";
                    break;
                case 7:
                    mes = "Julio";
                    break;
                case 8:
                    mes = "Agosto";
                    break;
                case 9:
                    mes = "Septiembre";
                    break;
                case 10:
                    mes = "Octubre";
                    break;
                case 11:
                    mes = "Noviembre";
                    break;
                case 12:
                    mes = "Diciembre";
                    break;


                 
            }
            return mes;
        }
    }

    public class EData
    {
        
        public string Empleado { get; set; }
        public string Salario { get; set; }
    }

    public class PData
    {
        public string Fecha { get; set; }
        public string Id { get; set; }
        public string Total { get; set; }
       
    }

    public class SData
    {
        public string Paciente { get; set; }
        public string Importe { get; set; }
        public string Pagado { get; set; }
     
    }
}
