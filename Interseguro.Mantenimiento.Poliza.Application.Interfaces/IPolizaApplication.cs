using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Application.Interfaces
{
    public interface IPolizaApplication
    {
        Task<ResponseDto> RegistrarPolizaXPersonaAsync(RequestPolizaDto polizaDto);
        Task<ResponseDto> ListarRegistrosPolizaAsync(FilterPolizaDto filterPolizaDto);
        Task<ResponseDto> FiltrarPolizaFormAsync(string cod_poliza);
    }
}
