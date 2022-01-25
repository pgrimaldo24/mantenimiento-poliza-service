using Interseguro.Mantenimiento.Poliza.Api.Extensions.Contracts;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Interseguro.Mantenimiento.Poliza.Api.Installers
{
    internal class RegisterAppSettings : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingsSection);
            services.AddSingleton(cfg => cfg.GetService<IOptions<AppSetting>>().Value);
        }
    }
}
