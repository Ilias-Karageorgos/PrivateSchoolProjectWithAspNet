using PrivateSchoolProjectWithAspNet.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PrivateSchoolProjectWithAspNet.Repositories.Repository
{
    public class GenRepository<TEntity> : IGenRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public GenRepository(DbContext context)
        {
            Context = context;
        }

        public async Task<TEntity> Get(int? id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public void ModifyEntity(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }                
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Add(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Context.Entry(entity).State = EntityState.Added;
        }

        public void Remove(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}