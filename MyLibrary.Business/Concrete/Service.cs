using MyLibrary.Business.Abstract;
using MyLibrary.DataAccess.Abstract;
using MyLibrary.DataAccess.Concrete;
using MyLibrary.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Business.Concrete
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;

        }
        public void Create(TEntity entity)
        {
            _repository.Create(entity);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
           return await _repository.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _repository.GetAllAsync(predicate,includeProperties);
        }

        public TEntity GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updateEntity =  _repository.Update(entity);
            _unitOfWork.Commit();
            return updateEntity;
        }
    }
}
