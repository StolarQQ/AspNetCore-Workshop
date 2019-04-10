using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiServer.Controllers;
using WebApiServer.Model;
using Xunit;

namespace Api.UnitTests.Controllers.MeasurmentTests
{
    public class MeasurementControllersUnitTests
    {
        [Fact]
        public async Task get_all_measurment()
        {
            //Arrange

            var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(get_all_measurment));
            var controller = new MeasurementController(repository);

            //Act

            var response = await controller.GetAll() as ObjectResult;
            var measurments = response.Value as List<Measurement>;

            //Assert

            Assert.Equal(200, response.StatusCode);
            Assert.Equal(5, measurments.Count);                       

        }


        [Fact]
        public async Task get_measurement_with_existing_id()
        {
            // Arrange 
            var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(get_measurement_with_existing_id));
            var controller = new MeasurementController(repository);
            var expectedValue = 0.25m;

            // Act
            var response = await controller.Get(1) as ObjectResult;
            var measurement = response.Value as Measurement;

            // Assert
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(expectedValue, measurement.Value);
        }

        [Fact]
        public async Task get_measurement_with_not_existing_id()
        {
            // Arrange 
            var repository = MeasurementContextMocker.GetInMemoryMeasurementsRepository(nameof(get_measurement_with_not_existing_id));
            var controller = new MeasurementController(repository);
            var expectedMessage = "The Measurement record couldn't be found.";

            // Act
            var response = await controller.Get(10) as ObjectResult;

            // Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Equal(expectedMessage, response.Value);
        }

    }
}
