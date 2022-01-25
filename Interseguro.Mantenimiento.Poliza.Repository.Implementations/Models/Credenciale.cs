using System;
using System.Collections.Generic;

#nullable disable

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations.Models
{
    public partial class Credenciale
    {
        public int CodCredencial { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool? Flag { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
