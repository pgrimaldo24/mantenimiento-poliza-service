using System;
using System.Collections.Generic;

#nullable disable

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Polizas = new HashSet<Poliza>();
        }

        public string CodPersona { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string NomPersona { get; set; }

        public virtual ICollection<Poliza> Polizas { get; set; }
    }
}
