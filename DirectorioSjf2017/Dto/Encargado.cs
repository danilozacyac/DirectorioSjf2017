using System;
using System.Linq;
using PadronApi.Dto;

namespace DirectorioSjf2017.Dto
{
    public class Encargado : Titular
    {
        private int idOrganismo;
        private int idTpoOrg;
        private int idFuncion;


        /// <summary>
        /// Indica el organismo del cual esta encargado
        /// </summary>
        public int IdOrganismo
        {
            get
            {
                return this.idOrganismo;
            }
            set
            {
                this.idOrganismo = value;
                this.OnPropertyChanged("IdOrganismo");
            }
        }

        /// <summary>
        /// Indica si el organismo es un Tribunal Colegiado o un Pleno de Circuito
        /// </summary>
        public int IdTpoOrg
        {
            get
            {
                return this.idTpoOrg;
            }
            set
            {
                this.idTpoOrg = value;
                this.OnPropertyChanged("IdTpoOrg");
            }
        }


        public int IdFuncion
        {
            get
            {
                return this.idFuncion;
            }
            set
            {
                this.idFuncion = value;
                this.OnPropertyChanged("IdFuncion");
            }
        }
    }
}
