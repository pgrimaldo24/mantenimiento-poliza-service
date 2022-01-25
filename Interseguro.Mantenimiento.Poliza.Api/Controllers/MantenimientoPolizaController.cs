using Interseguro.Mantenimiento.Poliza.Application.Interfaces;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Common.Exceptions;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using Interseguro.Mantenimiento.Poliza.CrossCutting.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoPolizaController : Controller
    {
        ResponseDto response = new ResponseDto();

        private readonly Lazy<IPolizaApplication> _polizaApplication;

        public MantenimientoPolizaController(IOptions<AppSetting> appSettings)
        {
            _polizaApplication = new Lazy<IPolizaApplication>(() => IoCAutofacContainer.Current.Resolve<IPolizaApplication>());
        }

        private IPolizaApplication PolizaApplication
        {
            get { return _polizaApplication.Value; }
        } 

        [HttpPost("RegistrarPolizaXPersona")]
        public async Task<JsonResult> RegistrarPolizaXPersona([FromBody] RequestPolizaDto polizaDto)
        {
            try
            {
                response = await PolizaApplication.RegistrarPolizaXPersonaAsync(polizaDto);
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

        [HttpPost("ListarRegistrosPoliza")]
        public async Task<JsonResult> ListarRegistrosPoliza([FromBody] FilterPolizaDto filterPolizaDto)
        {
            try
            {
                response = await PolizaApplication.ListarRegistrosPolizaAsync(filterPolizaDto);
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

        [HttpGet("FiltrarPolizaForm")]
        public async Task<JsonResult> FiltrarPolizaForm(string cod_poliza)
        {
            try
            {
                response = await PolizaApplication.FiltrarPolizaFormAsync(cod_poliza);
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
