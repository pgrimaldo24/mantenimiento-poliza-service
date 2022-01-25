
namespace Interseguro.Mantenimiento.Poliza.Domain.Models
{
    public partial class PolizaEntity
    {
        public string NumPoliza { get; set; }
        public string CodPersona { get; set; }
        public string FecInicioVigencia { get; set; }
        public decimal? MontoPrimaBruta { get; set; }
        public int? Igv { get; set; }
        public decimal? MontoPrimaNeta { get; set; }
        public bool Status { get; set; }
        public virtual PersonaEntity CodPersonaNavigation { get; set; }
    }
}
