namespace Interseguro.Mantenimiento.Poliza.CrossCutting.Dto
{
    public class InformePolizaDto
    {
        public string NumPoliza { get; set; }
        public string CodPersona { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Fecha_Inicio_Vigencia { get; set; }
        public decimal? Monto_Prima_Bruta { get; set; }
        public int? IGV { get; set; }
        public decimal? Monto_Prima_Neta { get; set; } 
    }
}
