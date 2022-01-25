using System;

namespace Interseguro.Mantenimiento.Poliza.CrossCutting.Dto
{
    public class RequestPolizaDto
    {
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public string Cod_Persona { get; set; }
        public string Fecha_Inicio_Vigencia { get; set; }
        public decimal Monto_Prima_Bruta { get; set; }
        public int IGV { get; set; } 
        public string Cod_Poliza { get; set; }
    }
}
