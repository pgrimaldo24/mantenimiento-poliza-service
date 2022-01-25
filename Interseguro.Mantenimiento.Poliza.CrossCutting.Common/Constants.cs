namespace Interseguro.Mantenimiento.Poliza.CrossCutting.Common
{
    public class Constants
    {
        public struct CodigoEstado
        {
            public const int Ok = 200;
            public const int Created = 201;
            public const int NotFound = 404;
            public const int InternalServerError = 500;
            
            public struct Login
            {
                public const int CredencialesIncorrectas = 1;
                public const int UsuarioNoExiste = 2;
                public const string ErrorUsuarioNoEncontrado = "El usuario no se encuentra registrado en la aplicación";
            }
        }
          
        public struct Service
        {
            public const string MensajeOK = "Se pocesó correctamente.";
            public const string Created = "Created";
        }

        public struct UserClaims
        {
            public const string UserId = "UserId";
            public const string Usuario = "Usuario";
            public const string Token = "Token"; 
        }

        public struct DateTimeFormats
        {
            public const string DD_MM_YYYY = "dd/MM/yyyy";
            public const string DD_MM_YYYY_HH_MM_SS = "dd/MM/yyyy HH:mm:ss";
            public const string DD_MM_YYYY_HH_MM_TT_12 = "dd/MM/yyyy hh:mm tt";
            public const string DD_MM_YYYY_HH_MM_SS_TT_12 = "dd/MM/yyyy hh:mm:ss tt";
            public const string DD_MM_YYYY_HH_MM_24 = "dd/MM/yyyy HH:mm";
            public const string DD_MM_YYYY_HH_MM_SS_FFF = "yyyyMMddHHmmssFFF";
            public const string DD_MM_YYY_HH_MM_SS = "ddMMyyyHHmmss";
            public const string YYYY_MM_DD = "yyyyMMdd";
        }
    }
}
