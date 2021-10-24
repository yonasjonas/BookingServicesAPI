using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingApplication.Models;
using BookingApplication.Services;


namespace BookingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ServicesService _servicesService;

        public ServicesController(ServicesService bookService)
        {
            _servicesService = bookService;
        }

        [HttpGet]
        public ActionResult<List<Service>> Get() =>
            _servicesService.Get();

        [HttpGet("{id:length(24)}", Name = "GetService")]
        public ActionResult<Service> Get(string id)
        {
            var service = _servicesService.Get(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        [HttpPost]
        public ActionResult<Service> Create(Service service)
        {
            _servicesService.Create(service);

            return CreatedAtRoute("GetService", new { id = service.Id.ToString() }, service);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Service serviceIn)
        {
            var service = _servicesService.Get(id);

            if (service == null)
            {
                return NotFound();
            }

            _servicesService.Update(id, serviceIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var service = _servicesService.Get(id);

            if (service == null)
            {
                return NotFound();
            }

            _servicesService.Remove(service.Id);

            return NoContent();
        }
    }
}
