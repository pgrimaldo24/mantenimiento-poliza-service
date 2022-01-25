using System;
using System.Collections.Generic;

#nullable disable

namespace Interseguro.Mantenimiento.Poliza.Domain.Models
{
    public partial class PersonaEntity
    {
        //public PersonaEntity()
        //{
        //    Polizas = new HashSet<PolizaEntity>();
        //}
        public string CodPersona { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string NomPersona { get; set; }

        public virtual ICollection<PolizaEntity> Polizas { get; set; }
    }
}
