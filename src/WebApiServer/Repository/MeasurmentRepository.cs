using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiServer.DbContexts;
using WebApiServer.Model;

namespace WebApiServer.Repository
{
    public class MeasurmentRepository : IMeasurmentRepository<Measurment>
    {
        private readonly MeasurmentContext _measurmentContext;

        public MeasurmentRepository(MeasurmentContext measurmentContext)
        {
            _measurmentContext = measurmentContext;
        }

        public async Task<Measurment> Get(long id)
        => await _measurmentContext.Measurments.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Measurment>> GetAll()
        => await _measurmentContext.Measurments.ToListAsync();

        public async Task Add(Measurment entity)
        {
            await _measurmentContext.Measurments.AddAsync(entity);
            await _measurmentContext.SaveChangesAsync();
        }

        public async Task Update(Measurment measurment, Measurment entity)
        {
            measurment.Name = entity.Name;
            measurment.Value = entity.Value;
            measurment.CreatedAt = entity.CreatedAt;
            measurment.CreatedBy = entity.CreatedBy;

            await _measurmentContext.SaveChangesAsync();
        }

        public async Task Delete(Measurment measurment)
        {
            _measurmentContext.Measurments.Remove(measurment);
            await _measurmentContext.SaveChangesAsync();
        }
    }
}
