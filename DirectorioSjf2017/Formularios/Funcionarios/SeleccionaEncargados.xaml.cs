using DirectorioSjf2017.Dto;
using DirectorioSjf2017.Model;
using DirectorioSjf2017.Singletons;
using PadronApi.Singletons;
using ScjnUtilities;
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
using Telerik.Windows.Controls;

namespace DirectorioSjf2017.Formularios.Funcionarios
{
    /// <summary>
    /// Interaction logic for SeleccionaEncargados.xaml
    /// </summary>
    public partial class SeleccionaEncargados
    {
        private Encargado selectedEncargado;
        int idOrganismo, idTpoOrg;

        public SeleccionaEncargados(int idOrganismo, int idTpoOrg)
        {
            InitializeComponent();
            this.idOrganismo = idOrganismo;
            this.idTpoOrg = idTpoOrg;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GTitulares.DataContext = EncargadosSingleton.Encargados;
            CbxFunciones.DataContext = FuncionesSingleton.Funciones;
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
            {
                tempString = StringUtilities.PrepareToAlphabeticalOrder(tempString);

                GTitulares.DataContext = (from n in EncargadosSingleton.Encargados
                                          where n.NombreStr.ToUpper().Contains(tempString)
                                          select n).ToList();
            }
            else
                GTitulares.DataContext = EncargadosSingleton.Encargados;
        }

        private void GTitulares_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            selectedEncargado = GTitulares.SelectedItem as Encargado;
        }

        private void CbxFunciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (CbxFunciones.SelectedIndex == -1)
                selectedEncargado.IdFuncion = 0;
            else
                selectedEncargado.IdFuncion = Convert.ToInt32(CbxFunciones.SelectedValue);

            selectedEncargado.IdOrganismo = idOrganismo;
            selectedEncargado.IdTpoOrg = idTpoOrg;

            bool completed = new EncargadosModel().UpdateEncargado(selectedEncargado);

            if(!completed)
            {
                MessageBox.Show("No se pudo completar la operación, favor de volverlo a intentar");
                return;
            }

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgregaEncargados addEncarg = new AgregaEncargados(EncargadosSingleton.Encargados) { Owner = this };
            addEncarg.ShowDialog();
        }
    }
}
