﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PadronApi.Dto;
using PadronApi.Model;
using PadronApi.Singletons;
using ScjnUtilities;
using DirectorioSjf2017.Formularios.Funcionarios;
using DirectorioSjf2017.Dto;
using DirectorioSjf2017.Model;

namespace DirectorioSjf2017.Formularios.OrganismosF
{
    /// <summary>
    /// Interaction logic for ActualizarVerOrganismo.xaml
    /// </summary>
    public partial class ActualizarVerOrganismo
    {

        private Pais selectedPais;
        private Estado selectedEstado;
        private Ciudad selectedCiudad;

        private Adscripcion selectedAdscripciones;
        private TipoOrganismo selectedTipoOrg;

        private Encargado selectedEncargado;

        private ObservableCollection<Materia> listaMaterias;
        private ObservableCollection<Encargado> listaEncargados;

        private Organismo organismo;
        private Organismo organismoOriginal;
        private bool? isUpdating;


        /// <summary>
        /// Permite actualizar la información relativa al organismo señalado
        /// </summary>
        /// <param name="organismo">Organismo que se va a actualizar</param>
        /// <param name="isUpdating">Indica si el organismo podrá ser modificado o solamente se visualizará la información</param>
        public ActualizarVerOrganismo(Organismo organismo, bool isUpdating)
        {
            InitializeComponent();
            organismoOriginal = new OrganismoModel().GetOrganismos(organismo.IdOrganismo);
            this.organismo = organismo;
            this.isUpdating = isUpdating;
            RbtnAgregaFuncionario.IsEnabled = isUpdating;
            RbtnEliminar.IsEnabled = isUpdating;
            Grid3.IsEnabled = isUpdating;

            if (!isUpdating)
            {
                BtnAceptar.Visibility = Visibility.Collapsed;
                BtnCancelar.Content = "Salir";
                this.Header = "Ver información";
                BtnAddEncargado.Visibility = Visibility.Collapsed;
                BtnDelEncargado.Visibility = Visibility.Collapsed;
                RbtnAgregaFuncionario.Visibility = Visibility.Collapsed;
                RbtnEliminar.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.Header = "Actualizar organismo";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxTipoOrg.DataContext = ElementalPropertiesSingleton.TipoOrganismo;
            CbxDistribucion.DataContext = ElementalPropertiesSingleton.Distribucion;
            CbxCircuito.DataContext = new ElementalPropertiesModel().GetCircuitos();
            CbxOrdinal.DataContext = new ElementalPropertiesModel().GetOrdinales();
            CbxPais.DataContext = PaisesSingleton.Paises;

            this.DataContext = organismo;

            listaEncargados = new EncargadosModel().GetEncargados(organismo.IdOrganismo);
            GridEncargados.DataContext = listaEncargados;

            listaMaterias = new Materia().GetMaterias();
            CbxMateria1.DataContext = listaMaterias;

            LoadNoBindings();
        }


        private void LoadNoBindings()
        {
            PaisEstadoModel model = new PaisEstadoModel();

            organismo.Adscripciones = new TitularModel().GetTitulares(organismo);
            GridIntegrantes.DataContext = organismo.Adscripciones;

            CbxTipoOrg.SelectedValue = organismo.TipoOrganismo;
            CbxOrdinal.SelectedValue = organismo.Ordinal;
            CbxCircuito.SelectedValue = organismo.Circuito;
            CbxDistribucion.SelectedValue = organismo.TipoDistr;
            int idPais = model.GetPaises(organismo.Estado).IdPais;
            CbxPais.SelectedValue = idPais;



            char[] materias = organismo.Materia.ToCharArray();

            if (materias.Count() == 1)
                CbxMateria1.SelectedValue = Convert.ToInt16(materias[0].ToString());
            if (materias.Count() == 2)
            {
                CbxMateria1.SelectedValue = Convert.ToInt16(materias[0].ToString());
                CbxMateria2.SelectedValue = Convert.ToInt16(materias[1].ToString());
            }
            if (materias.Count() == 3)
            {
                CbxMateria1.SelectedValue = Convert.ToInt16(materias[0].ToString());
                CbxMateria2.SelectedValue = Convert.ToInt16(materias[1].ToString());
                CbxMateria3.SelectedValue = Convert.ToInt16(materias[2].ToString());
            }

        }

        private void CbxTipoOrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TxtOrganismo.Text = String.Empty;
            selectedTipoOrg = CbxTipoOrg.SelectedItem as TipoOrganismo;

            if (selectedTipoOrg.IdGrupo == 0)
            {
                GpxMaterias.IsEnabled = false;
                CbxOrdinal.IsEnabled = false;
                CbxCircuito.IsEnabled = false;
                LblDescripcion.IsEnabled = false;

                CbxCircuito.SelectedIndex = -1;
                CbxOrdinal.SelectedIndex = -1;

                foreach (Materia materia in listaMaterias)
                    materia.IsChecked = false;
                LblDescripcion.Visibility = Visibility.Collapsed;
            }
            else
            {
                GpxMaterias.IsEnabled = true;
                CbxOrdinal.IsEnabled = true;
                CbxCircuito.IsEnabled = true;
                LblDescripcion.IsEnabled = true;
                LblDescripcion.Visibility = Visibility.Visible;
            }
        }



        private void RbtnAgregaFuncionario_Click(object sender, RoutedEventArgs e)
        {
            SeleccionaFuncionarios select = new SeleccionaFuncionarios(organismo, true) { Owner = this };
            select.ShowDialog();
            organismo.TotalAdscritos = organismo.Adscripciones.Count;
        }

        private void RbtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedAdscripciones == null)
            {
                MessageBox.Show("Antes de continuar debes seleccionar al titular que ya no pertenece a esta integración");
                return;
            }

            MessageBoxResult result = MessageBox.Show("¿Estas seguro de que este funcionario ya no es integrante de este tribunal?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                TitularModel model = new TitularModel();
                bool complete = model.EliminaAdscripcion(selectedAdscripciones, true);

                if (complete)
                {
                    //try
                    //{
                    //    organismo.Adscripciones.Remove(selectedAdscripciones);
                    //}
                    //catch (TargetInvocationException) { }
                    //int indexOf = organismo.Adscripciones.IndexOf(selectedAdscripciones);
                    //organismo.Adscripciones.RemoveAt(indexOf);
                    organismo.Adscripciones = new TitularModel().GetTitulares(organismo);
                    GridIntegrantes.DataContext = organismo.Adscripciones;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la relación de este integrante con el organismos, vuelva a intentarlo");

                }

                organismo.TotalAdscritos = organismo.Adscripciones.Count;
            }
        }

        

        #region Valida informacion

        private void TxtPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (TxtCp.Text.Length >= 5)
            {
                e.Handled = true;
                return;
            }

            e.Handled = VerificationUtilities.IsNumber(e.Text);
            TxtCp.Text.Trim();
        }

        private void TxtTelValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = VerificationUtilities.IsNumberOrGuion(e.Text);
        }

        private void TxtsLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;

            if (!String.IsNullOrEmpty(box.Text) || !String.IsNullOrWhiteSpace(box.Text))
                box.Text = VerificationUtilities.TextBoxStringValidation(box.Text);

        }


        #endregion


        #region Direccion

        private void CbxPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPais = CbxPais.SelectedItem as Pais;


            if (selectedPais.Estados == null)
                selectedPais.Estados = new PaisEstadoModel().GetEstados(selectedPais.IdPais);


            CbxEstado.DataContext = selectedPais.Estados;
            CbxEstado.SelectedValue = organismo.Estado;
            CbxEstado.IsEnabled = true;
            CbxCiudad.DataContext = null;
        }

        private void CbxEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedEstado = CbxEstado.SelectedItem as Estado;

                if (selectedEstado.Ciudades == null)
                    selectedEstado.Ciudades = new PaisEstadoModel().GetCiudades(selectedEstado.IdEstado);


                if (selectedPais.IdPais == 39 && CbxCircuito.IsEnabled)
                {
                    Ordinales selec = (from n in ElementalPropertiesSingleton.Circuitos
                                       where n.IdEstado == selectedEstado.IdEstado
                                       select n).ToList()[0];

                    CbxCircuito.SelectedValue = selec.IdOrdinal;
                }

                CbxCiudad.DataContext = selectedEstado.Ciudades;
                CbxCiudad.SelectedValue = organismo.Ciudad;
                CbxCiudad.IsEnabled = true;
            }
            catch (NullReferenceException)
            {
                CbxEstado.SelectedIndex = -1;
            }
        }



        private void CbxCiudad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedCiudad = CbxCiudad.SelectedItem as Ciudad;
            }
            catch (NullReferenceException)
            {
                CbxCiudad.SelectedIndex = -1;
            }
        }

        #endregion

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {

            if ((selectedTipoOrg.IdTipoOrganismo > 2 && selectedTipoOrg.IdTipoOrganismo < 10) && (CbxCircuito.SelectedIndex == -1))
            {
                MessageBox.Show("Antes de continuar debes de seleccionar el Circuito del organismo que intentas crear");
                return;
            }
            else
            {

                organismo.Ordinal = Convert.ToInt32(CbxOrdinal.SelectedValue);
                organismo.Circuito = Convert.ToInt32(CbxCircuito.SelectedValue);
                organismo.Materia = String.Empty;

                if (CbxMateria1.SelectedIndex != -1)
                {
                    organismo.Materia += ((Materia)CbxMateria1.SelectedItem).IdMateria;

                    if (CbxMateria2.SelectedIndex != -1)
                    {
                        organismo.Materia += ((Materia)CbxMateria2.SelectedItem).IdMateria;

                        if (CbxMateria3.SelectedIndex != -1)
                        {
                            organismo.Materia += ((Materia)CbxMateria3.SelectedItem).IdMateria;
                        }
                    }
                }
            }

            if (String.IsNullOrEmpty(TxtOrganismo.Text) || String.IsNullOrWhiteSpace(TxtOrganismo.Text))
            {
                MessageBox.Show("Para continuar ingresa el nombre o descripción del organismo que intentas crear");
                return;
            }

            if (CbxEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar el estado donde esta localizado el organismo");
                return;
            }

            if (String.IsNullOrEmpty(TxtCalle.Text) || String.IsNullOrWhiteSpace(TxtCalle.Text))
            {
                MessageBox.Show("Ingresa la calle y número donde se encuentra ubicado el organismo");
                return;
            }
            else if (TxtCalle.Text.StartsWith("Calle"))
            {
                char[] letras = TxtCalle.Text.ToCharArray();

                if (!Char.IsDigit(letras[6]))
                {
                    MessageBox.Show("El campo Calle no puede contener la palabra calle");
                    return;
                }

            }

            if (TxtColonia.Text.StartsWith("Col ") || TxtColonia.Text.StartsWith("Col. ") || TxtColonia.Text.StartsWith("Colonia "))
            {
                MessageBox.Show("El campo Colonia no puede contener la palabra colonia, ni ninguna de sus abreviaturas");
                return;
            }

            if (TxtDelMun.Text.StartsWith("Del ") || TxtDelMun.Text.StartsWith("Del. ") || TxtDelMun.Text.StartsWith("Delegacion ") || TxtDelMun.Text.StartsWith("Delegación ") || TxtDelMun.Text.StartsWith("Municipio ") || TxtDelMun.Text.StartsWith("Mun. ") || TxtDelMun.Text.StartsWith("Mun "))
            {
                MessageBox.Show("El campo Dlegación/Municipio no puede contener estas palabras, ni ninguna de sus abreviaturas");
                return;
            }


            if ((String.IsNullOrEmpty(TxtCp.Text) || String.IsNullOrWhiteSpace(TxtCp.Text)) || TxtCp.Text.Length < 4)
            {
                MessageBox.Show("Ingresa un Código Postal válido");
                return;
            }

            if (selectedPais.IdPais == 1 && (String.IsNullOrEmpty(TxtDelMun.Text) || String.IsNullOrWhiteSpace(TxtDelMun.Text)))
            {
                if (selectedEstado.IdEstado == 9)
                {
                    MessageBox.Show("Ingresa la delegación donde se encuentra ubicado el organismo");
                    return;
                }
                else
                {
                    MessageBox.Show("Ingresa el Municipio donde se encuentra ubicado el organismo");
                    return;
                }
            }



            organismo.OrganismoDesc = TxtOrganismo.Text;
            organismo.TipoOrganismo = Convert.ToInt32(CbxTipoOrg.SelectedValue);
            organismo.TipoOrganismoStr = CbxTipoOrg.Text;
            organismo.TipoDistr = Convert.ToInt32(CbxDistribucion.SelectedValue);
            organismo.Distribucion = CbxDistribucion.Text;
            organismo.Estado = Convert.ToInt32(CbxEstado.SelectedValue);

            if (CbxCiudad.SelectedIndex != -1)
                organismo.Ciudad = Convert.ToInt32(CbxCiudad.SelectedValue);

            organismo.OrganismoStr = StringUtilities.PrepareToAlphabeticalOrder(organismo.OrganismoDesc);

            OrganismoModel model = new OrganismoModel();


            Organismo orHistorial = model.GetOrganismos(organismo.IdOrganismo);

            if (!organismo.IsEqualTo(orHistorial))
            {
                model.UpdateOrganismo(organismo);
                model.InsertaHistorial(orHistorial);
            }

            DialogResult = true;
            this.Close();


        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            //organismo = organismoOriginal;
            DialogResult = false;
            this.Close();
        }

        private void LblDescripcion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string materias = String.Empty;

            int mat1 = Convert.ToInt16(CbxMateria1.SelectedValue);

            if (mat1 != 0)
            {


                if (mat1 == 2 || mat1 == 6 || mat1 == 7)
                    materias += "en Materia de " + CbxMateria1.Text;
                else
                    materias += "en Materia " + CbxMateria1.Text;

                int mat2 = Convert.ToInt16(CbxMateria2.SelectedValue);

                if (mat2 != 0)
                {
                    string materia2 = String.Empty;

                    if (mat2 == 2 || mat2 == 6 || mat2 == 7)
                        materia2 = "de " + CbxMateria2.Text;
                    else
                        materia2 = CbxMateria2.Text;

                    int mat3 = Convert.ToInt16(CbxMateria3.SelectedValue);

                    if (mat3 != 0)
                    {
                        string materia3 = String.Empty;

                        if (mat3 == 2 || mat3 == 6 || mat3 == 7)
                            materia3 = "de " + CbxMateria3.Text;
                        else
                            materia3 = CbxMateria3.Text;


                        materias += ", " + materia2 + " y " + materia3 + " ";
                    }
                    else
                    {
                        materias += " y " + materia2 + " ";
                    }
                    materias = materias.Replace("Materia", "Materias");
                }
                BtnAceptar.IsEnabled = true;
            }

            if (selectedTipoOrg.IdTipoOrganismo == 2)
            {
                if (CbxCircuito.SelectedIndex != -1)
                    TxtOrganismo.Text = ((CbxOrdinal.SelectedIndex != -1) ? CbxOrdinal.Text + " " : String.Empty) +
                        "Tribunal Colegiado " + materias + "del " + CbxCircuito.Text;
                else
                    MessageBox.Show("Selecciona el circuito al cual pertenece el tribunal");
            }
            else if (selectedTipoOrg.IdTipoOrganismo == 4)
            {
                if (CbxCircuito.SelectedIndex != -1)
                    TxtOrganismo.Text = ((CbxOrdinal.SelectedIndex != -1) ? CbxOrdinal.Text + " " : String.Empty) +
                        "Tribunal Unitario " + materias + " del " + CbxCircuito.Text;
                else
                    MessageBox.Show("Selecciona el circuito al cual pertenece el tribunal");
            }
            else if (selectedTipoOrg.IdTipoOrganismo == 8)
            {
                if (CbxCircuito.SelectedIndex != -1)
                    TxtOrganismo.Text = "Juzgado " + ((CbxOrdinal.SelectedIndex != -1) ? CbxOrdinal.Text + " " : String.Empty) + " de Distrito " +
                         materias + " del " + CbxCircuito.Text;
                else
                    MessageBox.Show("Selecciona el ordinal y el circuito al cual pertenece el tribunal");
            }
        }

        private void CbxMateria1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int materia1 = Convert.ToInt16(CbxMateria1.SelectedValue);

            if (materia1 > 0)
            {
                CbxMateria2.IsEnabled = true;
                CbxMateria2.DataContext = (from n in listaMaterias
                                           where n.IdMateria != materia1
                                           select n);
            }
            else
            {
                CbxMateria2.IsEnabled = false;
                CbxMateria2.SelectedValue = null;
                CbxMateria2_SelectionChanged(null, null);
            }
        }

        private void CbxMateria2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int materia2 = Convert.ToInt16(CbxMateria2.SelectedValue);

            if (materia2 > 0)
            {
                CbxMateria3.IsEnabled = true;
                CbxMateria3.DataContext = (from n in listaMaterias
                                           where n.IdMateria != Convert.ToInt16(CbxMateria1.SelectedValue) &&
                                           n.IdMateria != Convert.ToInt16(CbxMateria2.SelectedValue)
                                           select n);
            }
            else
            {
                CbxMateria3.IsEnabled = false;
                CbxMateria3.SelectedValue = null;
            }

        }

        private void TxtCp_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void CbxCircuito_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ordinales ordinal = CbxCircuito.SelectedItem as Ordinales;

            if (ordinal != null)
                CbxEstado.SelectedValue = ordinal.IdEstado;
        }

        private void CbxOrdinal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GridIntegrantes_SelectionChanged_1(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedAdscripciones = GridIntegrantes.SelectedItem as Adscripcion;
        }



        private void GIntegrantes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (isUpdating == true)
            {

                MessageBoxResult result = MessageBox.Show("¿Estas seguro de asignar a " +
                    selectedAdscripciones.Titular.Nombre + " " + selectedAdscripciones.Titular.Apellidos + " como presidente de este organismo?",
                    "Atención:", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    new TitularModel().UpdatePresidente(selectedAdscripciones.Titular.IdTitular, organismo.IdOrganismo);

                    foreach (Adscripcion adscrip in organismo.Adscripciones)
                    {
                        if (adscrip.Funcion == 1)
                            adscrip.Funcion = 0;
                    }

                    selectedAdscripciones.Funcion = 1;
                    organismo.TotalAdscritos = organismo.Adscripciones.Count;
                }
            }
        }


        private void RadWindow_PreviewClosed(object sender, Telerik.Windows.Controls.WindowPreviewClosedEventArgs e)
        {
            if (DialogResult != true && isUpdating == true)
            {
                organismo.OrganismoDesc = organismoOriginal.OrganismoDesc;
                organismo.OrganismoStr = organismoOriginal.OrganismoStr;
                organismo.TipoOrganismo = organismoOriginal.TipoOrganismo;
                organismo.TipoOrganismoStr = organismoOriginal.TipoOrganismoStr;
                organismo.Circuito = organismoOriginal.Circuito;
                organismo.Ordinal = organismoOriginal.Ordinal;
                organismo.Materia = organismoOriginal.Materia;
                organismo.Ciudad = organismoOriginal.Ciudad;
                organismo.Estado = organismoOriginal.Estado;
                organismo.Calle = organismoOriginal.Calle;
                organismo.Colonia = organismoOriginal.Colonia;
                organismo.Delegacion = organismoOriginal.Delegacion;
                organismo.Cp = organismoOriginal.Cp;
                organismo.Telefono = organismoOriginal.Telefono;
                organismo.Extension = organismoOriginal.Extension;
                organismo.Telefono2 = organismoOriginal.Telefono2;
                organismo.Extension2 = organismoOriginal.Extension2;
                organismo.Telefono3 = organismoOriginal.Telefono3;
                organismo.Extension3 = organismoOriginal.Extension3;
                organismo.Telefono4 = organismoOriginal.Telefono4;
                organismo.Extension4 = organismoOriginal.Extension4;
                organismo.Mail = organismoOriginal.Mail;
                organismo.Observaciones = organismoOriginal.Observaciones;
                organismo.TipoDistr = organismoOriginal.TipoDistr;
                organismo.Distribucion = organismoOriginal.Distribucion;
                organismo.Abreviado = organismoOriginal.Abreviado;
                organismo.Orden = organismoOriginal.Orden;
            }
        }

        private void BtnAddEncargado_Click(object sender, RoutedEventArgs e)
        {
            SeleccionaEncargados addEncargado = new SeleccionaEncargados(organismo.IdOrganismo, organismo.TipoOrganismo) { Owner = this };
            addEncargado.ShowDialog();

            listaEncargados = new EncargadosModel().GetEncargados(organismo.IdOrganismo);
            GridEncargados.DataContext = listaEncargados;
        }

        private void BtnDelEncargado_Click(object sender, RoutedEventArgs e)
        {
            if (selectedEncargado == null)
            {
                MessageBox.Show("Selecciona el encargado del organismo que deseas eliminar");
                return;
            }

            selectedEncargado.IdOrganismo = 0;
            selectedEncargado.IdTpoOrg = 0;
            selectedEncargado.IdFuncion = 0;

            bool completed = new EncargadosModel().UpdateEncargado(selectedEncargado);

            if (completed)
            {
                listaEncargados.Remove(selectedEncargado);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo completar la operación, favor de intentarlo más tarde");
            }
        }

        private void GridEncargados_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedEncargado = GridEncargados.SelectedItem as Encargado;
        }




    }
}
