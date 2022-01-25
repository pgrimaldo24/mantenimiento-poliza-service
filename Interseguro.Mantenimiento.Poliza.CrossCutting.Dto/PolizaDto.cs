using System;

namespace Interseguro.Mantenimiento.Poliza.CrossCutting.Dto
{
    public class PolizaDto
    {
        public DateTime Fecha_Inicio_Vigencia { get; set; }
        public double Monto_Prima_Bruta { get; set; }
        public double IGV { get; set; }
        public double Monto_Prima_Neta { get; set; }
        public string Cod_Poliza { get; set; }
    }
}
