using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, Context> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where Context : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (Context context = new Context())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (Context context = new Context())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            using (Context context = new Context())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (includes != null) query = includes(query);

                return query.FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            using (Context context = new Context())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (includes != null) query = includes(query);
                if (filter != null) query = query.Where(filter);

                return query.ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (Context context = new Context())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
