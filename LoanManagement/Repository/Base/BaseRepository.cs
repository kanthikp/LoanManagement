using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoanManagement.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext { get; set; }

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            var _entity = _dbContext.Set<TEntity>().Attach(entity);
            _entity.State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;

        }

    }
}
