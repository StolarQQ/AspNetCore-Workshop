using Microsoft.EntityFrameworkCore;
using WebApiServer.Model;

namespace WebApiServer.DbContexts
{
    public class MeasurementContext : DbContext
    {
        public MeasurementContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Measurement> Measurments { get; set; }
    }
}
