using Microsoft.EntityFrameworkCore;
using MyLibrary.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DataAccess.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MyLibraryDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MyLibraryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);

        }

        public void Delete(int id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
        }

  
        public TEntity GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;

        }
        public async Task<IEnumerable<TEntity>> GetAllAsync (Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

    }
}
