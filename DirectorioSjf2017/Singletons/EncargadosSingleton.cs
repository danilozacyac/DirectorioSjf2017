using System;
using System.Collections.ObjectModel;
using System.Linq;
using DirectorioSjf2017.Dto;
using DirectorioSjf2017.Model;

namespace DirectorioSjf2017.Singletons
{
    class EncargadosSingleton
    {
        private static ObservableCollection<Encargado> encargados;

        private EncargadosSingleton()
        {
        }

        public static ObservableCollection<Encargado> Encargados
        {
            get
            {
                if (encargados == null)
                    encargados = new EncargadosModel().GetEncargados();

                return encargados;
            }
        }

        public static int ResetEncargados
        {
            set
            {
                encargados = null;
            }
        }
    }
}