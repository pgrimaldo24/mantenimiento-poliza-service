using Interseguro.Mantenimiento.Poliza.Api.Extensions.Contracts;
using Interseguro.Mantenimiento.Poliza.Api.Installers.Filter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Api.Installers
{
    internal class RegisterSwagger : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mantenimiento Poliza"
                });

                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "Enter 'Bearer' following by space and JWT.",
                        Type = SecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = ParameterLocation.Header
                    });

                //TODO: revisar lo comentado
                options.OperationFilter<SwaggerAuthorizeCheckOperationFilter>();
                 
            });
        }
    }
}
