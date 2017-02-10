using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using PadronApi.Dto;
using PadronApi.Model;
using PadronApi.Singletons;
using ScjnUtilities;
using DirectorioSjf2017.Dto;
using DirectorioSjf2017.Model;
using DirectorioSjf2017.Singletons;

namespace DirectorioSjf2017.Formularios.Funcionarios
{
    /// <summary>
    /// Interaction logic for AgregaEncargados.xaml
    /// </summary>
    public partial class AgregaEncargados
    {
        private bool isUpdating;
        private bool mostrarEnCombo;
        private ObservableCollection<Encargado> catalogoTitulares;
        private Encargado encargado;
        string qCambio = String.Empty;

        private Adscripcion selectedAdscripcion;

        public AgregaEncargados(ObservableCollection<Encargado> catalogoTitulares)
        {
            InitializeComponent();
            this.catalogoTitulares = catalogoTitulares;
            this.encargado = new Encargado();
            this.isUpdating = false;
            encargado.Estado = 1;
        }

        public AgregaEncargados(Encargado encargado, bool isUpdating)
        {
            InitializeComponent();
            this.encargado = encargado;
            this.isUpdating = isUpdating;

            if (!isUpdating)
            {
                PanelPrincipal.IsEnabled = false;
                BtnGuardar.Visibility = Visibility.Hidden;
                this.Header = "Ver información";
                BtnSalir.Content = "Salir";
               
            }
            else
            {
                this.Header = "Actualizar titular";
                
            }
            mostrarEnCombo = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.CargaTitulos(2);

            if (encargado.Genero == 2)
                TbGenero_Checked(null, null);
            else
                TbGenero.IsChecked = false;

            this.DataContext = encargado;

            if (mostrarEnCombo)
            {
                CbxGrado.SelectedValue = encargado.IdTitulo;
            }

            qCambio = String.Empty;

            TxtApellidos.Focus();
        }

        private void BtnEliminaAdscripcion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar la adscripción de este titular?", "Atención",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                encargado.IdOrganismo = 0;
                encargado.IdTpoOrg = 0;
                encargado.IdFuncion = 0;
            }

        }

        private void BtnAgregaAdscripcion_Click(object sender, RoutedEventArgs e)
        {
            SeleccionaOrgAdscrip org = new SeleccionaOrgAdscrip(encargado, isUpdating) { Owner = this };
            org.ShowDialog();
        }

        

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (CbxGrado.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona el título del encargado", "Seleccionar título", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(TxtNombre.Text) || String.IsNullOrEmpty(TxtApellidos.Text))
            {
                MessageBox.Show("Ingresa el nombre y los apellidos del encargado", "Agregar encargado", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            encargado.IdTitulo = Convert.ToInt32(CbxGrado.SelectedValue);
            encargado.NombreStr = StringUtilities.PrepareToAlphabeticalOrder(encargado.Nombre) + " " + StringUtilities.PrepareToAlphabeticalOrder(encargado.Apellidos);

            EncargadosModel model = new EncargadosModel();
            bool exito = false;

            if (!isUpdating)
            {
                if (model.DoEncargadoExist(encargado.NombreStr))
                {
                    MessageBox.Show("El encargado que deseas agregar ya existe", "Encargados", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            encargado.Nombre = VerificationUtilities.TextBoxStringValidation(encargado.Nombre);
            encargado.Apellidos = VerificationUtilities.TextBoxStringValidation(encargado.Apellidos);

            if (isUpdating)
            {
                exito = model.UpdateEncargado(encargado);

                if (!exito)
                {
                    MessageBox.Show("Hubo un problema con la actualización intentelo nuevamente");
                    return;
                }

                encargado.TotalAdscripciones = encargado.Adscripciones.Count;

                this.Close();

            }
            else
            {
                exito = model.InsertaEncargado(encargado);

                if (!exito)
                {
                    MessageBox.Show("Hubo un problema al ingresar el titular intentelo nuevamente");
                    return;
                }
                else
                {
                    EncargadosSingleton.Encargados.Add(encargado);
                    this.Close();
                }
            }
        }

        private void TxtPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = VerificationUtilities.ContieneCaractNoPermitidos(e.Text);
        }


       

        private void TbGenero_Checked(object sender, RoutedEventArgs e)
        {
            ImGenero.Source = new BitmapImage(new Uri("pack://application:,,,/DirectorioSjf2017;component/Resources/female_128.png", UriKind.Absolute));
            encargado.Genero = 2;
            this.CargaTitulos(2);
            this.CbxGrado.SelectedValue = 15;
        }

        private void TbGenero_Unchecked(object sender, RoutedEventArgs e)
        {
            ImGenero.Source = new BitmapImage(new Uri("pack://application:,,,/DirectorioSjf2017;component/Resources/male_128.png", UriKind.Absolute));
            encargado.Genero = 1;
            this.CargaTitulos(1);
            this.CbxGrado.SelectedValue = 3;
        }

        private void CargaTitulos(int genero)
        {
            CbxGrado.DataContext = (from n in TituloSingleton.Titulos
                                    where n.IdGenero == genero || n.IdGenero == 3
                                    select n);
        }

       
    }
}