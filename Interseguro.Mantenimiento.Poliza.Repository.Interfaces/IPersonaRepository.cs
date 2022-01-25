using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Repository.Interfaces
{
    public interface IPersonaRepository
    {
        Task<UserDto> GetUserCredential(CredentialDto credentialDto);
    }
}
