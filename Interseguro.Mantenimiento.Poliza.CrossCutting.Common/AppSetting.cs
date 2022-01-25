namespace Interseguro.Mantenimiento.Poliza.CrossCutting.Common
{
    public class AppSetting
    {
        public ConnectionString ConnectionStrings { get; set; }
        public string Secret { get; set; }
        public int HoursOfExpires { get; set; } 
    }

    public class ConnectionString
    {
        public string BDInterseguro { get; set; }
    }
}
