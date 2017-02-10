using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using DirectorioSjf2017.Formularios.OrganismosF;
using DirectorioSjf2017.Singletons;
using PadronApi.Dto;
using Telerik.Windows.Controls;

namespace DirectorioSjf2017
{
    /// <summary>
    /// Interaction logic for Directorio.xaml
    /// </summary>
    public partial class Directorio
    {

        private Organismo selectedOrganismo;
        int tipoProceso = 1;

        public Directorio()
        {
            InitializeComponent();
            worker.DoWork += this.WorkerDoWork;
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.LaunchBusyIndicator();

            

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


        #region Background Worker

        private BackgroundWorker worker = new BackgroundWorker();

        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (tipoProceso == 1)
            {
                var x = OrganismoDirSingleton.Organismos;
            }

            
        }

        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (tipoProceso == 1)
            {
                GOrganismos.DataContext = OrganismoDirSingleton.Organismos;
                LblTotales.Content = OrganismoDirSingleton.Organismos.Count + " registros";
            }

            //if (tipoProceso == 3)
            //    queImprime = null;

            //fileName = String.Empty;
            //Dispatcher.BeginInvoke(new Action<ObservableCollection<Organismos>>(this.UpdateGridDataSource), e.Result);
            this.BusyIndicator.IsBusy = false;
        }

        private void LaunchBusyIndicator()
        {
            if (!worker.IsBusy)
            {
                this.BusyIndicator.IsBusy = true;
                worker.RunWorkerAsync();
            }
        }

        #endregion
       
    }
}
