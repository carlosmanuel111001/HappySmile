using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using appClinica.Adapters.SQLServerDataAccess.Contexts;
using appClinica.Core.Infraestructure.Repository.Concrete;
using appClinica.Core.Application.UseCases;
using appClinica.Core.Domain.Models;

using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appClinica.Ports.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        public CitaUseCase CreateService() {
            ClinicaDB db = new ClinicaDB();
            CitaRepository repository = new CitaRepository(db);
            CitaUseCase service = new CitaUseCase(repository);
            return service;
        }

        // GET: api/<CitaController>
        [HttpGet]
        public ActionResult<IEnumerable<Cita>> Get()
        {
            var service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<CitaController>/5
        [HttpGet("{id}")]
        public ActionResult<Especialista> Get(Guid id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<CitaController>
        [HttpPost]
        public ActionResult<Especialista> Post([FromBody] Cita cita)
        {
            try
            {
                var service = CreateService();
                var result = service.Create(cita);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    error = ex.Message,
                });
            }
        }

        // PUT api/<CitaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Cita cita)
        {
            var service = CreateService();
            cita.citaId = id;
            service.Update(cita);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<CitaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var service = CreateService();
                service.Delete(id);

                return Ok(new
                {
                    message = "Eliminado exitosamente"
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    error = ex.Message,
                });
            }
        }
    }
}
