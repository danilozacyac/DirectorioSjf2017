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
using DirectorioSjf2017.Dto;

namespace DirectorioSjf2017.Formularios.Funcionarios
{
    /// <summary>
    /// Interaction logic for SeleccionaOrgAdscrip.xaml
    /// </summary>
    public partial class SeleccionaOrgAdscrip
    {
        // Organismo organismo;
        ObservableCollection<Organismo> catalogoOrganismo;
        //ObservableCollection<Adscripcion> adscripciones;
        bool isUpdating = false, actualizaTiraje = false;

        Encargado encargado;

        public SeleccionaOrgAdscrip(Encargado encargado, bool isUpdating)
        {
            InitializeComponent();
            this.encargado = encargado;
            this.isUpdating = isUpdating;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GOrganismos.DataContext = (from n in OrganismoDirSingleton.Organismos
                                       where n.TipoOrganismo == 2 || n.TipoOrganismo == 10
                                       select n);
            CbxFunciones.DataContext = FuncionesSingleton.Funciones;

                CbxFunciones.SelectedValue = 0;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            encargado.IdFuncion = Convert.ToInt32(CbxFunciones.SelectedValue);

            DialogResult = true;
            this.Close();
        }

        private void GOrganismos_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            Organismo selectedOrganismo = GOrganismos.SelectedItem as Organismo;
            encargado.IdOrganismo = selectedOrganismo.IdOrganismo;
            encargado.IdTpoOrg = selectedOrganismo.TipoOrganismo;
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper().Trim();

            long digitos = 0;
            Int64.TryParse(tempString, out digitos);

            if (!String.IsNullOrEmpty(tempString))
            {
                if (digitos == 0)
                    tempString = StringUtilities.PrepareToAlphabeticalOrder(tempString);

                GOrganismos.DataContext = (from n in catalogoOrganismo
                                           where n.OrganismoStr.Contains(tempString)
                                           select n).ToList();
            }
            else
                GOrganismos.DataContext = catalogoOrganismo;
        }


    }
}
