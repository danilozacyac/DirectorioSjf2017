using PadronApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }
    }
}
