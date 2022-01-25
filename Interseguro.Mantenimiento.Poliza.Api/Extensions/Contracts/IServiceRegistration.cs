using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Interseguro.Mantenimiento.Poliza.Api.Extensions.Contracts
{
    public interface IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
    }
}
