using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.CrossCutting.Common.Exceptions
{
    public class TechnicalException : Exception, ISerializable
    {
        public string TransactionId { get; }
        public int ErrorCode { get; }
        public dynamic Data { get; set; }

        public TechnicalException(string message) : base(message)
        {
            this.ErrorCode = Constants.CodigoEstado.InternalServerError;
            this.TransactionId = DateTime.Now.ToString(Constants.DateTimeFormats.DD_MM_YYYY_HH_MM_SS_FFF);
        }
    }
}
