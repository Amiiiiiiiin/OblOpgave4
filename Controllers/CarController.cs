using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OblOpgave4.Models;
using OblOpgave4.Managers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OblOpgave4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private CarManager _manager = new CarManager();

        // GET: api/Cars?maxPrice=<value> 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] int? maxPrice)
        {
            IEnumerable<Car> cars = _manager.GetAll(maxPrice);

            if (cars.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(cars);
            }

        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Car car = _manager.GetById(id);
            if (car == null) return NotFound("No such item, id: " + id);
            return Ok(car);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public Car Post([FromBody] Car newCar)
        {
            return _manager.AddCar(newCar);
        }

        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            Car car = _manager.GetById(id);
            return _manager.Delete(id);
        }
    }
}
