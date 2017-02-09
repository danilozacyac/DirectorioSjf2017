using System;
using System.Collections.ObjectModel;
using System.Linq;
using DirectorioSjf2017.Model;
using PadronApi.Dto;

namespace DirectorioSjf2017.Singletons
{
    public class OrganismoDirSingleton
    {
        private static ObservableCollection<Organismo> organismos;

        private OrganismoDirSingleton()
        {
        }

        public static ObservableCollection<Organismo> Organismos
        {
            get
            {
                if (organismos == null)
                    organismos = new OrganismoDirModel().GetOrganismos();

                return organismos;
            }
        }
    }
}