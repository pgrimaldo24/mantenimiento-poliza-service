using System;

namespace Interseguro.Mantenimiento.Poliza.Domain.Models
{
    public class CredencialesEntity
    {
        public int CodCredencial { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool? Flag { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
