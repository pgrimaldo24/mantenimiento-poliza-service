using Interseguro.Mantenimiento.Poliza.CrossCutting.Common;
using Interseguro.Mantenimiento.Poliza.CrossCutting.IoC;
using Interseguro.Mantenimiento.Poliza.Repository.Interfaces.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Repository.Implementations.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly AppSetting settings;
        private Dictionary<Type, object> repositories;
        private bool _disposed;


        public UnitOfWork(
            IOptions<AppSetting> settings, 
            IHttpContextAccessor httpContext)
        {
            this.settings = settings.Value;
            _context = new DataContext(new DbContextOptionsBuilder<DataContext>().UseSqlServer(this.settings.ConnectionStrings.BDInterseguro).Options, httpContext);
            _httpContext = httpContext;
        } 

        public DbContext Get()
        {
            return _context;
        }

        public T Repository<T>() where T : class
        {
            if (repositories == null)
                repositories = new Dictionary<Type, object>();

            var type = typeof(T);
            if (!repositories.ContainsKey(type))
            {
                repositories.Add(type, IoCAutofacContainer.Current.Resolve<T>("context", _context));
            }

            return (T)repositories[type];
        }

        public void SaveChanges()
        {
            TrackChanges();
            _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            TrackChanges();
            return await _context.SaveChangesAsync();
        }
        private void TrackChanges()
        {
            if (_context.ChangeTracker.Entries().Any(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                var identity = _httpContext?.HttpContext?.User.FindFirst(Constants.UserClaims.UserId)?.Value ?? "SYSTEM";
            }

        }
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                    if (repositories != null)
                        repositories.Clear();

                    _context.Dispose();
                }

            _disposed = true;
        }

    }
}
