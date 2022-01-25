using System;
using System.Collections.Generic;

#nullable disable

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations.Models
{
    public partial class Poliza
    {
        public string NumPoliza { get; set; }
        public string CodPersona { get; set; }
        public string FecInicioVigencia { get; set; }
        public decimal? MontoPrimaBruta { get; set; }
        public int? Igv { get; set; }
        public decimal? MontoPrimaNeta { get; set; }

        public virtual Persona CodPersonaNavigation { get; set; }
    }
}
