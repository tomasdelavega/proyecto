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
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace ClienteFisio.Interfaz.Materiales
{
    /// <summary>
    /// Interaction logic for VPedidos.xaml
    /// </summary>
    public partial class VPedidos : Window
    {
        ObservableCollection<PedidoData> _PedidoCollection = new ObservableCollection<PedidoData>();
        ObservableCollection<PedidoData> _PedidoCollectionRegs = new ObservableCollection<PedidoData>();
        private List<TMaterial> listMateriales = new List<TMaterial>();
        private List<TPedido> listPedidos = new List<TPedido>();
     
        private TPedido pedido;

        public VPedidos()
        {
            InitializeComponent();
            pedido = new TPedido();
            pedido.TLineaPedidos = new List<TLineaPedidos>();
       
        }

        public ObservableCollection<PedidoData> PedidoCollection
        { get { return _PedidoCollection; } }

        public ObservableCollection<PedidoData> PedidoCollectionRegs
        { get { return _PedidoCollectionRegs; } }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Owner.IsEnabled = true;
            this.Owner.Activate();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                listMateriales = ClienteWCF.getServicios().recuperarMateriales();
                if (listMateriales == null)
                {
                    listMateriales = new List<TMaterial>();
                    lblA2.Content = "No hay materiales en la base de datos";
                }
                else
                {
                    foreach (TMaterial m in listMateriales)
                    {
                        comboMat.Items.Add(m.Nombre);
                    }
                    if(listPeds.Items.Count > 0)
                        listPeds.SelectedIndex = 0;
                    if (comboMat.Items.Count > 0)
                        comboMat.SelectedIndex = 0;

                }


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

            this.cargarPeds();
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            if(!this.añadido(comboMat.SelectedItem.ToString()))//añadir a la lista si el material no se ha añadido todavia
            {
                if (txtPrecio.Text == "")
                    lblAvisos2.Content = "Introduce el precio de cada unidad.";
                else if (txtUds.Text == "")
                    lblAvisos2.Content = "Introduce el número de unidades de dicho material.";
                else if (comboMat.SelectedIndex == -1)
                    lblAvisos2.Content = "Material no seleccionado.";
                else
                {
                    lblAvisos2.Content = "";
                    try
                    {
                        int cant = Int32.Parse(txtUds.Text);
                        float precio = float.Parse(txtPrecio.Text); 
                        TLineaPedidos lineaP = new TLineaPedidos();
                        lineaP.Cantidad = cant;
                        lineaP.Precio = precio;                 
                        lineaP.Id_material = listMateriales.ElementAt(comboMat.SelectedIndex).Id_material;
                 
                      
                    
                        pedido.TLineaPedidos.Add(lineaP);
                        _PedidoCollection.Add(new PedidoData {Material = comboMat.SelectedItem.ToString(),Cantidad = txtUds.Text, Precio = txtPrecio.Text , Total = ""+cant*precio+"" });
                        lblAvisos.Content = "";
                        txtPrecio.Text = "";
                        txtUds.Text = "";
                        
                    

                   }
                    catch (FormatException ex)
                    {
                        lblAvisos2.Content = "¿Has introducido correctamente el precio o la cantidad?.";
                    }
                }  
            }

            
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (datePicker.SelectedDate == null)
                lblAvisos.Content = "Selecciona una fecha.";
            else if (listViewLinP.Items.Count == 0)
                lblAvisos.Content = "No hay materiales en el pedido.";
            else
            {
                
            
      
                try
                {
                    pedido.Fecha = datePicker.SelectedDate.Value;
                    pedido.Observaciones = txtComentarios.Text;
                    ClienteWCF.getServicios().registrarPedido(pedido);
                    this.cargarPeds();
                    txtPrecio.Text = "";
                    txtUds.Text = "";
                    _PedidoCollection.Clear();
                    lblAvisos.Content = "Pedido registrado.";
                    txtComentarios.Text = "";
                    lblA3.Content = "";
                    pedido = new TPedido();
                    pedido.TLineaPedidos = new List<TLineaPedidos>();

                    //this.Close();

                }
                catch (FaultException<ErrorSql> ex)
                {
                    MessageBox.Show("No se ha podido registrar el pedido. " + ex.Detail.Content);
                }
                catch (EndpointNotFoundException ex)
                {
                    MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                }
            }

        }

        private void btnQuitar_Click(object sender, RoutedEventArgs e)
        {
            if (listViewLinP.SelectedIndex != -1)
            {
                pedido.TLineaPedidos.RemoveAt(listViewLinP.SelectedIndex);
                _PedidoCollection.RemoveAt(listViewLinP.SelectedIndex);
                txtComentarios.Text = "";
      
               
                
            }
        }

        private bool añadido(String nomMat)//indica si un determinado material ha sido añadido ya a la linea de pedidos
        {
            bool add = false;
            int idMat = getIdMaterial(nomMat);
            foreach (TLineaPedidos l in pedido.TLineaPedidos)
                if (l.Id_material == idMat)
                    return true;
            return add;
        }

        private int getIdMaterial(String nombre)
        {
            int Id = 0;
            foreach (TMaterial m in listMateriales)
                if (m.Nombre == nombre)
                    return m.Id_material;

            return Id;
        }

        private void listPeds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listPeds.SelectedIndex != -1)
            {
                _PedidoCollectionRegs.Clear();
                TPedido p = listPedidos.ElementAt(listPeds.SelectedIndex);
                float importeTot = 0;
                int canTot = 0;
                foreach (TLineaPedidos l in p.TLineaPedidos)
                {
                    String material;
                    if (this.getMaterial(l.Id_material) == null)
                        material = "*Eliminado*";
                    else
                        material = this.getMaterial(l.Id_material).Nombre;

                    float totLinea = float.Parse(Convert.ToString(l.Precio * l.Cantidad));
                    _PedidoCollectionRegs.Add(new PedidoData { Material = material, Cantidad = Convert.ToString(l.Cantidad), Precio = Convert.ToString(l.Precio), Total = Convert.ToString(totLinea) });

                    importeTot += totLinea; ;
                    canTot += l.Cantidad;

                }
                txtComs.Text = p.Observaciones;
                lblCant2.Content = canTot + " uds";
                lblPrecio2.Content = importeTot + " €";
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (listPeds.SelectedIndex != -1)
            {

                MessageBoxResult r = MessageBox.Show("¿Estas seguro de eliminar este pedido? Si lo eliminas no contarás con el para realizar las cuentas del mes.", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (r == MessageBoxResult.Yes)
                {
                    try
                    {
                        int seleccion = listPeds.SelectedIndex;
                        ClienteWCF.getServicios().eliminarPedido(listPedidos.ElementAt(seleccion).Id_pedido);
                        listPedidos.RemoveAt(seleccion);
                        listPeds.Items.RemoveAt(seleccion);
                        _PedidoCollectionRegs.Clear();
                        lblCant2.Content = "";
                        lblPrecio2.Content = "";
                        lblAvisos.Content = "";
                        if(listPedidos.Count == 0)
                            lblA3.Content = "No hay pedidos registrados.";

                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);
                    }
                    catch (EndpointNotFoundException ex)
                    {
                        MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");

                    }
                }

            }
        }
        public TMaterial getMaterial(int id)
        {
            TMaterial mr = null;
            foreach (TMaterial m in listMateriales)
            {
                if (m.Id_material == id)
                    return m;
            }
            return mr;

        }
        private void cargarPeds()
        {
            try{
                listPedidos = ClienteWCF.getServicios().getPedidos();
                listPeds.Items.Clear();
                if (listPedidos != null)
                {
                    foreach (TPedido p in listPedidos)
                    {
                        listPeds.Items.Add(p.Fecha.ToShortDateString() + "   Id: " + p.Id_pedido);
                    }
                    if (listPeds.Items.Count > 0)
                        listPeds.SelectedIndex = 0;
                }
                else
                {
                    listPedidos = new List<TPedido>();
                    lblA3.Content = "No hay pedidos registrados.";
                }



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
            
    }
    public class PedidoData
    {
        public string Material { get; set; }
        public string Cantidad { get; set; }
        public string Precio { get; set; }
        public string Total { get; set; }
    }
}
