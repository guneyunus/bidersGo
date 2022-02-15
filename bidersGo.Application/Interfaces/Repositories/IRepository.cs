using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        Task AsyncUpdate(T entity);
        void Delete(T entity);
    }
}
