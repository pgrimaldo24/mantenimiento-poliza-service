using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using System;

namespace Interseguro.Mantenimiento.Poliza.CrossCutting.Dto
{
    public class ResponseDto
    {
        public ResponseDto()
        {
            TransactionId = DateTime.Now.ToString(Constants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
            Status = Constants.CodigoEstado.Ok;
            Message = Constants.Service.MensajeOK; 
        }

        public string TransactionId { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
