using DirectorioSjf2017.Model;
using DirectorioSjf2017.Reportes;
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

namespace DirectorioSjf2017
{
    /// <summary>
    /// Interaction logic for Directorio.xaml
    /// </summary>
    public partial class Directorio
    {
        public Directorio()
        {
            InitializeComponent();
        }

        private void RadWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GOrganismos.DataContext = new OrganismoDirModel().GetOrganismos();

            //new WordReport().ListadoEncargados();
        }
    }
}
