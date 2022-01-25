using Autofac.Extensions.DependencyInjection;
using Interseguro.Mantenimiento.Poliza.Api.Extensions;
using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using Interseguro.Mantenimiento.Poliza.CrossCutting.IoC;
using Interseguro.Mantenimiento.Poliza.Repository.Implementations.Base;
using Interseguro.Mantenimiento.Poliza.Repository.Implementations.Data;
using Interseguro.Mantenimiento.Poliza.Repository.Interfaces.Base;
using Interseguro.Mantenimiento.Poliza.Repository.Interfaces.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace Interseguro.Mantenimiento.Poliza.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddServicesInAssembly(Configuration);
            services.AddControllers()
               .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            //var coonection = Configuration.GetConnectionString("BDInterseguro"); 
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingsSection);
            services.AddSingleton(cfg => cfg.GetService<IOptions<AppSetting>>().Value);
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSwaggerGen();

            var initialize = IoCAutofacContainer.Initialize(services);
            return new AutofacServiceProvider(initialize);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
             
            } 

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
           );

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)  
               .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Interseguro.Mantenimiento.Poliza.Api v1"));
        }
    }
}
