using Interseguro.Mantenimiento.Poliza.Application.Interfaces;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using Interseguro.Mantenimiento.Poliza.CrossCutting.IoC;
using Interseguro.Mantenimiento.Poliza.Repository.Interfaces;
using Interseguro.Mantenimiento.Poliza.Repository.Interfaces.Data;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Application.Implementations
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly AppSetting _appSettings;
        private Lazy<IUnitOfWork> _unitOfWork; 

        public UsuarioApplication(IOptions<AppSetting> appSettings)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>()); 
        }

        private IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork.Value;
            }
        }
        private IPersonaRepository PersonaRepository
        {
            get
            {
                return UnitOfWork.Repository<IPersonaRepository>();
            }
        }

        public async Task<ResponseDto> GetUser(CredentialDto credentialDto)
        {
            ResponseDto response = new ResponseDto();
            var userDto = await PersonaRepository.GetUserCredential(credentialDto);
            if (userDto == null)
            {
                response.Status = Constants.CodigoEstado.Ok;
                response.Message = Constants.CodigoEstado.Login.ErrorUsuarioNoEncontrado;
            }
            response.Data = userDto;
            return response;
        } 
    }
}
