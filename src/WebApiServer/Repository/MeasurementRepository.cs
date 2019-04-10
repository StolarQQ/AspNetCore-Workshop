using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiServer.DbContexts;
using WebApiServer.Model;

namespace WebApiServer.Repository
{
    public class MeasurmentRepository : IMeasurementRepository<Measurement>
    {
        private readonly MeasurementContext _measurmentContext;

        public MeasurmentRepository(MeasurementContext measurmentContext)
        {
            _measurmentContext = measurmentContext;
        }

        public async Task<Measurement> Get(long id)
        => await _measurmentContext.Measurments.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Measurement>> GetAll()
        => await _measurmentContext.Measurments.ToListAsync();

        public async Task Add(Measurement entity)
        {
            await _measurmentContext.Measurments.AddAsync(entity);
            await _measurmentContext.SaveChangesAsync();
        }

        public async Task Update(Measurement measurment, Measurement entity)
        {
            measurment.Name = entity.Name;
            measurment.Value = entity.Value;
            measurment.CreatedAt = entity.CreatedAt;
            measurment.CreatedBy = entity.CreatedBy;

            await _measurmentContext.SaveChangesAsync();
        }

        public async Task Delete(Measurement measurment)
        {
            _measurmentContext.Measurments.Remove(measurment);
            await _measurmentContext.SaveChangesAsync();
        }
    }
}
