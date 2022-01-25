using Interseguro.Mantenimiento.Poliza.Domain.Models;
using Interseguro.Mantenimiento.Poliza.Repository.Implementations.Data.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations.Data
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContext;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContext) 
            : base(options)
        {
            _httpContext = httpContext;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.ApplyConfiguration(new PersonaConfiguration()); 
            builder.ApplyConfiguration(new PolizaConfiguration());
            builder.ApplyConfiguration(new CredencialesConfiguration());
        }

        public virtual DbSet<PersonaEntity> Persona { get; set; }
        public virtual DbSet<PolizaEntity> Poliza { get; set; } 
        public virtual DbSet<CredencialesEntity> Credenciales { get; set; }

    }
}
