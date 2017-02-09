using System;
using System.Collections.ObjectModel;
using System.Linq;
using PadronApi.Dto;
using PadronApi.Model;

namespace DirectorioSjf2017.Singletons
{
    public class TirularSingleton
    {
        private static ObservableCollection<Titular> titular;

        private TirularSingleton()
        {
        }

        public static ObservableCollection<Titular> Titulares
        {
            get
            {
                if (titular == null)
                    titular = new TitularModel().GetTitulares(true);

                return titular;
            }
        }
    }
}