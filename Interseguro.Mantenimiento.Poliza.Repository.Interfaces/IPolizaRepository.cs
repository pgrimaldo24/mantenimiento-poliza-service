using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto.Base;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Repository.Interfaces
{
    public interface IPolizaRepository
    {
        Task<PaginationResultDto<InformePersonaDto>> ListarPolizaAsync(FilterPolizaDto filterPolizaDto);
        Task<InformePolizaDto> ObtenerPolizaByIdAsync(string cod_poliza);
    }
}
