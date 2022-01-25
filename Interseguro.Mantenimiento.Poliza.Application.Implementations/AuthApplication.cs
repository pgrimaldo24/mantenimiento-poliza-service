using Interseguro.Mantenimiento.Poliza.Application.Interfaces;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using Interseguro.Mantenimiento.Poliza.CrossCutting.IoC;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Application.Implementations
{
    public class AuthApplication : IAuthApplication
    {
        private readonly AppSetting _appSettings;
        private readonly Lazy<IUsuarioApplication> _usuarioApplication;

        public AuthApplication(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value; 
            _usuarioApplication = new Lazy<IUsuarioApplication>(() => IoCAutofacContainer.Current.Resolve<IUsuarioApplication>());
        }

        private IUsuarioApplication UsuarioApplication
        {
            get { return _usuarioApplication.Value; }
        }

        public async Task<ResponseDto> AuthenticationAsync(CredentialDto credentialDto)
        { 
            ResponseDto response = await UsuarioApplication.GetUser(credentialDto);

            if (response.Status != Constants.CodigoEstado.Ok)
                return response;

            var usuario = (UserDto)response.Data; 
            usuario.Token = GenerarToken(usuario);
            response.Data = usuario.Token;
            return response; 
        }

        private string GenerarToken(UserDto userDto)
        {
            DateTime expires = DateTime.Now.AddHours(_appSettings.HoursOfExpires);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                { 
                    new Claim(Constants.UserClaims.Usuario, userDto.Usuario.ToString())
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        } 
    }
}
