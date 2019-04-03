using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiServer.Model;
using WebApiServer.Repository;

namespace WebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurmentController : Controller
    {
        private readonly IMeasurmentRepository<Measurment> _measurmentRepository;

        public MeasurmentController(IMeasurmentRepository<Measurment> measurmentRepository)
        {
            _measurmentRepository = measurmentRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var measurments = await _measurmentRepository.GetAll();

            return Ok(measurments);
        }
        
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get([FromBody] long id)
        {
            var measurment = await _measurmentRepository.Get(id);

            return Ok(measurment);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Measurment measurment)
        {
            await _measurmentRepository.Add(measurment);

            return CreatedAtAction(nameof(Post), new { id = measurment.Id, measurment });
        }

        [HttpPut]
        public async Task<IActionResult> Put(long id, Measurment measurment)
        {
            var measurmentToUpdate = await _measurmentRepository.Get(id);

            await _measurmentRepository.Update(measurmentToUpdate, measurment);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var measurmentToDelete = await _measurmentRepository.Get(id);

            await _measurmentRepository.Delete(measurmentToDelete);

            return NoContent();
        }
               
    }
}