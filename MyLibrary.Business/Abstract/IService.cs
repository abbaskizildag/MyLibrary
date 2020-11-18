using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Business.Abstract
{
    public interface IService<TEntity> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetByID(int id);

        void Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
