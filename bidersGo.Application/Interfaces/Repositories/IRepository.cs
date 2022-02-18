using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Application.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        List<T> GetAll();
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(T entity);
        Task AsyncUpdate(T entity);
        void Delete(T entity);
    }
}
