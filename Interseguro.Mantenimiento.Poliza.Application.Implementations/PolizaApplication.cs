using Interseguro.Mantenimiento.Poliza.Application.Interfaces;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Dto;
using Interseguro.Mantenimiento.Poliza.CrossCutting.IoC;
using Interseguro.Mantenimiento.Poliza.Domain.Models;
using Interseguro.Mantenimiento.Poliza.Repository.Interfaces;
using Interseguro.Mantenimiento.Poliza.Repository.Interfaces.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Application.Implementations
{
    public class PolizaApplication : IPolizaApplication
    {

        private Lazy<IUnitOfWork> _unitOfWork;

        public PolizaApplication(IOptions<AppSetting> appSettings)
        { 
            _unitOfWork = new Lazy<IUnitOfWork>(() => IoCAutofacContainer.Current.Resolve<IUnitOfWork>());
        }

        private IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork.Value;
            }
        }
        private IPolizaRepository PolizaRepository
        {
            get
            {
                return UnitOfWork.Repository<IPolizaRepository>();
            }
        }

        public async Task<ResponseDto> FiltrarPolizaFormAsync(string cod_poliza)
        {
            var response = new ResponseDto();
            var informe = await PolizaRepository.ObtenerPolizaByIdAsync(cod_poliza); 
            response.Data = informe; 
            return response;
        }

        public async Task<ResponseDto> ListarRegistrosPolizaAsync(FilterPolizaDto filterPolizaDto)
        {
            var response = new ResponseDto(); 
            var result = await PolizaRepository.ListarPolizaAsync(filterPolizaDto); 
            response.Data = result;
            return response;
        }

        public async Task<ResponseDto> RegistrarPolizaXPersonaAsync(RequestPolizaDto polizaDto)
        {
            var response = new ResponseDto();
            if (string.IsNullOrEmpty(polizaDto.ToString())) 
                return response;
            
            var persona = await SetPersona(polizaDto);
            var poliza = await SetPoliza(polizaDto);
            UnitOfWork.Set<PersonaEntity>().Add(persona);
            UnitOfWork.Set<PolizaEntity>().Add(poliza);
            UnitOfWork.SaveChanges();
            response.Status = Constants.CodigoEstado.Created;
            response.Message = Constants.Service.Created;
            response.Data = Constants.Service.MensajeOK;
            return response; 
        }


        private async Task<PersonaEntity> SetPersona(RequestPolizaDto requestPolizaDto)
        {
            var personaEntity = new PersonaEntity
            {
                CodPersona = requestPolizaDto.Cod_Persona,
                ApePaterno = requestPolizaDto.ApellidoPaterno,
                ApeMaterno = requestPolizaDto.ApellidoMaterno,
                NomPersona = requestPolizaDto.Nombres
            }; 
            return personaEntity;
        }

        private async Task<PolizaEntity> SetPoliza(RequestPolizaDto requestPolizaDto)
        {
            var polizaEntity = new PolizaEntity
            {
                NumPoliza = requestPolizaDto.Cod_Poliza,
                FecInicioVigencia = requestPolizaDto.Fecha_Inicio_Vigencia,
                Igv = requestPolizaDto.IGV,
                MontoPrimaBruta = requestPolizaDto.Monto_Prima_Bruta,
                MontoPrimaNeta = requestPolizaDto.Monto_Prima_Bruta * requestPolizaDto.IGV / 100, 
                CodPersona = requestPolizaDto.Cod_Persona
            }; 
            return polizaEntity;
        }
    }
}
