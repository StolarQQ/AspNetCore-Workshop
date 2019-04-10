using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiServer.Model;
using WebApiServer.DbContexts;
using WebApiServer.Repository;

namespace Api.UnitTests
{
    public static class MeasurementContextMocker
    {
        public static IMeasurementRepository<Measurement> GetInMemoryMeasurementsRepository(string dbName)
        {
            var options = new DbContextOptionsBuilder<MeasurementContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            MeasurementContext measurmentContext = new MeasurementContext(options);
            measurmentContext.FillDatabase();

            return new MeasurmentRepository(measurmentContext);
        }
    }
}
