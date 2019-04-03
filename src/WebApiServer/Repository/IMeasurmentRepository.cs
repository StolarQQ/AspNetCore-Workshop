using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.Model;

namespace WebApiServer.Repository
{
    public interface IMeasurmentRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(Measurment measurment, TEntity entity);
        Task Delete(Measurment measurment);
               
    }
}
