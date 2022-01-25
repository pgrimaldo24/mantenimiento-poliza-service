using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Interseguro.Mantenimiento.Poliza.Repository.Interfaces.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task Insert(T entity);
        void Update(T entity, bool activarDeteccion = false);
        Task Delete(object id);
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
    }
}
