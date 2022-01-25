using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<ResponseDto> GetUser(CredentialDto credentialDto);
    }
}
