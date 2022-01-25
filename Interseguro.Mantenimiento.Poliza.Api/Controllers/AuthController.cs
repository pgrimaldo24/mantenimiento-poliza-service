using Interseguro.Mantenimiento.Poliza.Application.Interfaces;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Common.Exceptions;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using Interseguro.Mantenimiento.Poliza.CrossCutting.IoC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        ResponseDto response = new ResponseDto();
        
        private readonly Lazy<IAuthApplication> _authApplication;
        
        public AuthController(IOptions<AppSetting> appSettings)
        {
            _authApplication = new Lazy<IAuthApplication>(() => IoCAutofacContainer.Current.Resolve<IAuthApplication>()); 
        }

        private IAuthApplication AuthApplication
        {
            get { return _authApplication.Value; }
        }

        [AllowAnonymous]
        [HttpPost("Authentication")]
        public async Task<JsonResult> Authentication([FromBody] CredentialDto credentialDto)
        { 
            try
            {
                response = await AuthApplication.AuthenticationAsync(credentialDto); 
            }
            catch (FunctionalException ex)
            {
                response = new ResponseDto { Status = ex.FuntionalCode, Message = ex.Message, Data = ex.Data, TransactionId = DateTime.Now.ToString(Constants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF) };
            }
            catch (TechnicalException ex)
            {
                response = new ResponseDto { Status = ex.ErrorCode, Message = ex.Message, Data = ex.Data, TransactionId = DateTime.Now.ToString(Constants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF) };
            }
            catch (Exception ex)
            {
                response = new ResponseDto { Status = Constants.CodigoEstado.InternalServerError, Message = ex.Message, TransactionId = DateTime.Now.ToString(Constants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF) };
            } 
            return new JsonResult(response);
        }
    }
}
