using Microsoft.EntityFrameworkCore;
using WebApiServer.Model;

namespace WebApiServer.DbContexts
{
    public class MeasurmentContext : DbContext
    {
        public MeasurmentContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Measurment> Measurments { get; set; }
    }
}
