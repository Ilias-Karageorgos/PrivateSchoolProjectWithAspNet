using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PrivateSchoolProjectWithAspNet.IRepositories
{
    public interface IGenRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int? id);
        Task<IEnumerable<TEntity>> GetAll();
        void Add(TEntity entity);
        void ModifyEntity(TEntity entity);
        void Remove(TEntity entity);
    }
}