using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto.Base;
using Interseguro.Mantenimiento.Poliza.Repository.Implementations.Data;
using Interseguro.Mantenimiento.Poliza.Repository.Implementations.Entexions;
using Interseguro.Mantenimiento.Poliza.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations
{
    public class PolizaRepository : IPolizaRepository
    {
        private readonly DataContext context;
        public PolizaRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<PaginationResultDto<InformePersonaDto>> ListarPolizaAsync(FilterPolizaDto filterPolizaDto)
        {
            var result = context.Poliza.Where(x => x.Status);

            if (!string.IsNullOrEmpty(filterPolizaDto.Cod_Poliza))
                result = result.Where(x => x.NumPoliza.Contains(filterPolizaDto.Cod_Poliza));

            return await result
               .Select(x => new InformePersonaDto()
               {
                   Cod_Poliza = x.NumPoliza.ToString(),
                   Cod_Persona = x.CodPersona.ToString(),
                   ApePaterno = x.CodPersonaNavigation.ApePaterno.Trim(),
                   ApeMaterno = x.CodPersonaNavigation.ApeMaterno.Trim(),
                   NomPersona = x.CodPersonaNavigation.NomPersona.Trim()
               }
           ).SortBy(filterPolizaDto.Order, filterPolizaDto.ColumnOrder).GetPagedAsync(filterPolizaDto.Page, filterPolizaDto.PageSize);
        }

        public async Task<InformePolizaDto> ObtenerPolizaByIdAsync(string cod_poliza)
        {
            return await context.Poliza
               .Where(c => c.NumPoliza.Equals(cod_poliza.ToString()) && c.Status)
               .Select(c => new InformePolizaDto
               {
                    NumPoliza = c.NumPoliza,
                    CodPersona = c.CodPersona,
                    ApellidoPaterno = c.CodPersonaNavigation.ApePaterno.Trim().ToString(),
                    ApellidoMaterno = c.CodPersonaNavigation.ApeMaterno.Trim().ToString(),
                    Nombres = c.CodPersonaNavigation.NomPersona.Trim().ToString(),
                    Fecha_Inicio_Vigencia = c.FecInicioVigencia,
                    IGV = c.Igv,
                    Monto_Prima_Bruta = c.MontoPrimaBruta,
                    Monto_Prima_Neta = c.MontoPrimaNeta 
               }).FirstOrDefaultAsync();
        }
    }
}
