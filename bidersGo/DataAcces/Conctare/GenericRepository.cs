using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bidersGo.DataAcces.Abstract;
using Microsoft.EntityFrameworkCore;

namespace bidersGo.DataAcces.Conctare
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }
        public async Task AsyncUpdate(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}