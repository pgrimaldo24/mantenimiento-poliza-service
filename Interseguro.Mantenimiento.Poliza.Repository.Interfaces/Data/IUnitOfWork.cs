using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Repository.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Dispose();
        void SaveChanges();
        Task<int> SaveChangesAsync();
        void Dispose(bool disposing);
        T Repository<T>() where T : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbContext Get();
    }
}
