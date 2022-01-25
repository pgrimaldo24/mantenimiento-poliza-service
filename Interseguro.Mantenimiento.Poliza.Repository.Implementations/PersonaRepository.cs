using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using Interseguro.Mantenimiento.Poliza.Repository.Implementations.Data;
using Interseguro.Mantenimiento.Poliza.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations
{
    public class PersonaRepository : IPersonaRepository
    {

        private readonly DataContext context;
        public PersonaRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<UserDto> GetUserCredential(CredentialDto credentialDto)
        {
            var response = new ResponseDto();
            var userEntity = await context.Credenciales.Where(x => x.Usuario.Equals(credentialDto.User) 
            && x.Contrasena.Equals(credentialDto.Password) && x.Flag.Equals(true)).FirstOrDefaultAsync();

            //(x => string.Equals(x.Usuario, credentialDto.User, StringComparison.InvariantCultureIgnoreCase)
            //&& string.Equals(x.Contrasena, credentialDto.Password, StringComparison.InvariantCultureIgnoreCase));
            if (userEntity == null) return null; 

            var credential = new UserDto
            {
                CodUsuario = userEntity.CodCredencial,
                Usuario = userEntity.Usuario.ToString()
            };

            return credential;
        }
    }
}
