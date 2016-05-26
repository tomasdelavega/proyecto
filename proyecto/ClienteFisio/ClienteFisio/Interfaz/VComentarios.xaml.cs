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
using System.ServiceModel;
using ClienteFisio.ClientWCF;
using System.Collections.ObjectModel;

namespace ClienteFisio.Interfaz
{
    /// <summary>
    /// Interaction logic for VComentarios.xaml
    /// </summary>
    ///
    public partial class VComentarios : Window
    {
        private ObservableCollection<ComData> _ComsCollection = new ObservableCollection<ComData>();
        private List<TComentario> listcomentarios = new List<TComentario>();
        public VComentarios()
        {
            InitializeComponent();
        }

        public ObservableCollection<ComData> ComsCollection
        { get { return _ComsCollection; } }

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
            try
            {
                listcomentarios = ClienteWCF.getServicios().getComentarios();
                if (listcomentarios == null)
                {
                    lblAvisos.Content = "No hay comentarios registrados.";
                    listcomentarios = new List<TComentario>();
                }
                else
                    foreach (TComentario c in listcomentarios)
                    {
                        String paciente = c.Dni_paciente;
                        try
                        {
                            
                            TPaciente p = ClienteWCF.getServicios().getPaciente(c.Dni_paciente);
                            if (p != null)
                                paciente = p.Nombre + " " + p.Apellidos;
                        }
                        catch (FaultException<ErrorSql> ex)
                        {
                            MessageBox.Show(ex.Detail.Content);
                            this.Close();

                        }

                        _ComsCollection.Add(new ComData { Paciente = paciente, Fecha = c.Fecha.ToString()});
                    }
            }
            catch(FaultException<ErrorSql> ex)
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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            lblAvisos.Content = "";
            if (listViewComs.SelectedIndex != -1)
            {
                MessageBoxResult r = MessageBox.Show("¿Seguro que quieres borrar este comentario?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (r == MessageBoxResult.Yes)
                {
                    int ind = listViewComs.SelectedIndex;
                    try
                    {
                        ClienteWCF.getServicios().borrarCom(listcomentarios.ElementAt(ind).Id);
                        listcomentarios.RemoveAt(ind);
                        _ComsCollection.RemoveAt(ind);
                        listViewComs.SelectedIndex = -1;
                        lblAvisos.Content = "Comentario borrado.";
                        textBox1.Text = "";


                    }
                    catch (FaultException<ErrorSql> ex)
                    {
                        MessageBox.Show(ex.Detail.Content);

                    }
                    catch (FaultException<Error> ex)
                    {
                        lblAvisos.Content = ex.Detail.Content;
                    }
                    catch (EndpointNotFoundException ex)
                    {
                        MessageBox.Show("No es posible conectar con el servidor. Comprueba la configuración de red o contacta con tu administrador.");
                    }
                }
                
            }
            else
                lblAvisos.Content = "Selecciona un comentario para eliminarlo.";
        }

        private void listViewPac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listViewComs.SelectedIndex != -1)
            {
                
                textBox1.Text = listcomentarios.ElementAt(listViewComs.SelectedIndex).Comentario;
            }
        }


    }
    public class ComData
    {
        public string Paciente { get; set; }
        public string Fecha { get; set; }
    }
}
