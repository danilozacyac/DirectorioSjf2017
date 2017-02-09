using DirectorioSjf2017.Dto;
using DirectorioSjf2017.Formularios.Funcionarios;
using DirectorioSjf2017.Formularios.OrganismosF;
using DirectorioSjf2017.Model;
using DirectorioSjf2017.Reportes;
using DirectorioSjf2017.Singletons;
using PadronApi.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Telerik.Windows.Controls;

namespace DirectorioSjf2017
{
    /// <summary>
    /// Interaction logic for Directorio.xaml
    /// </summary>
    public partial class Directorio
    {

        private Organismo selectedOrganismo;

        public Directorio()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GOrganismos.DataContext = OrganismoDirSingleton.Organismos;

            

            //new WordReport().ListadoEncargados();
        }


        private void GOrganismos_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            selectedOrganismo = GOrganismos.SelectedItem as Organismo;
        }

        private void InfoOrganismo_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOrganismo == null)
            {
                MessageBox.Show("Antes de continuar debes de seleccionar un organismo", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            ActualizarVerOrganismo verOrg = new ActualizarVerOrganismo(selectedOrganismo,false) { Owner = this };
            verOrg.ShowDialog();
        }

        private void ModificaOrganismo_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOrganismo == null)
            {
                MessageBox.Show("Antes de continuar debes de seleccionar un organismo", "Atención", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            ActualizarVerOrganismo verOrg = new ActualizarVerOrganismo(selectedOrganismo, true) { Owner = this };
            verOrg.ShowDialog();
        }

       
    }
}
