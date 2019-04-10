using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.Model;

namespace WebApiServer.Repository
{
    public interface IMeasurementRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(Measurement measurment, TEntity entity);
        Task Delete(Measurement measurment);
               
    }
}
