using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PadronApi.Dto;
using PadronApi.Model;
using PadronApi.Singletons;
using ScjnUtilities;
using DirectorioSjf2017.Singletons;

namespace DirectorioSjf2017.Formularios.Funcionarios
{
    /// <summary>
    /// Interaction logic for SeleccionaFuncionarios.xaml
    /// </summary>
    public partial class SeleccionaFuncionarios
    {
        private Organismo currentOrganismo;
        private Titular selectedTitular;
        private ObservableCollection<Titular> listaTitulares;
        bool isUpdatingOrganismo;

        ObservableCollection<ElementalProperties> tipoObras;
        ObservableCollection<TirajePersonal> listaTirajes;

        Adscripcion adscripcion;

        bool isUpdatingTiraje = false;

        public SeleccionaFuncionarios(Organismo currentOrganismo, bool isUpdatingOrganismo)
        {
            InitializeComponent();
            this.currentOrganismo = currentOrganismo;
            this.isUpdatingOrganismo = isUpdatingOrganismo;
            this.adscripcion = new Adscripcion();
        }

        public SeleccionaFuncionarios(Adscripcion adscripcion)
        {
            InitializeComponent();
            this.adscripcion = adscripcion;
            this.isUpdatingTiraje = true;
            this.currentOrganismo = adscripcion.Organismo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxFunciones.DataContext = FuncionesSingleton.Funciones;
            GTitulares.DataContext = TirularSingleton.Titulares; 
            adscripcion.Organismo = currentOrganismo;

        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
            {
                tempString = StringUtilities.PrepareToAlphabeticalOrder(tempString);

                GTitulares.DataContext = (from n in listaTitulares
                                          where n.NombreStr.ToUpper().Contains(tempString)
                                          select n).ToList();
            }
            else
                GTitulares.DataContext = listaTitulares;
        }

        private void GTitulares_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            selectedTitular = GTitulares.SelectedItem as Titular;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTitular == null && !isUpdatingTiraje )
            {
                MessageBox.Show("Para poder esablecer una relación Organismo-Titular debes seleccionar un funcionario");
                return;
            }
            else
            {

                if (currentOrganismo.Adscripciones == null)
                    currentOrganismo.Adscripciones = new ObservableCollection<Adscripcion>();


                adscripcion.Funcion = Convert.ToInt32(CbxFunciones.SelectedValue);

                if (isUpdatingTiraje)
                {
                    TitularModel model = new TitularModel();
                    model.EliminaAdscripcion(adscripcion, false);
                    model.EstableceAdscripcion(adscripcion, false);
                }
                else
                {
                    adscripcion.Titular = selectedTitular;
                    int yaExiste = 0;

                    foreach (Adscripcion ad in currentOrganismo.Adscripciones)
                    {
                        if (adscripcion.Titular.IdTitular == ad.Titular.IdTitular)
                            yaExiste++;
                    }

                    if (yaExiste == 0)
                    {
                        ObservableCollection<Adscripcion> currentAds = new TitularModel().GetAdscripcionesTitular(selectedTitular);
                        if (isUpdatingOrganismo)
                        {
                            TitularModel model = new TitularModel();
                            model.EstableceAdscripcion(adscripcion, true);
                        }

                        currentOrganismo.Adscripciones.Add(adscripcion);

                        if (currentAds.Count > 0)
                            MessageBox.Show("El titular que acabas de adscribir a este organismo ya se encontraba adscrito a otro organismo");
                    }
                }

                this.Close();
            }

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
