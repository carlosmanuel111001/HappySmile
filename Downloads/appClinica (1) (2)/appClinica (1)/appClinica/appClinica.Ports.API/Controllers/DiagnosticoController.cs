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
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DiagnosticoController : ControllerBase
    {

        public DiagnosticoUseCase CreateService()
        {
            ClinicaDB db = new ClinicaDB();
            DiagnosticoRepository repository = new DiagnosticoRepository(db);
            DiagnosticoUseCase service = new DiagnosticoUseCase(repository);
            return service;
        }

        // GET: api/<DiagnosticoController>
        [HttpGet]
        public ActionResult<IEnumerable<Diagnostico>> Get()
        {
            var service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<DiagnosticoController>/5
        //[HttpGet]
        //public ActionResult<Diagnostico> Get([FromQuery] Guid citaId, [FromQuery] Guid especialistaId)
        //{
        //    var service = CreateService();
        //    var diagnosticoId = new Tuple<Guid, Guid>(citaId, especialistaId);
        //    return Ok(service.GetById(diagnosticoId));
        //}

        [HttpGet("getByCita")]
        public ActionResult<IEnumerable<Diagnostico>> GetByCita(Guid id)
        {
            var service = CreateService();
            return Ok(service.GetByCita(id));
        }

        [HttpGet("getByEspecialista")]
        public ActionResult<IEnumerable<Diagnostico>> GetByEspecialista(Guid id)
        {
            var service = CreateService();
            return Ok(service.GetByEspecialista(id));
        }

        // POST api/<DiagnosticoController>
        [HttpPost]
        public ActionResult<Diagnostico> Post([FromBody] Diagnostico diagnostico)
        {
            try
            {
                var service = CreateService();
                var result = service.Create(diagnostico);
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

        // PUT api/<DiagnosticoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DiagnosticoController>/5
        [HttpDelete()]
        public ActionResult Delete([FromQuery] Guid citaId, [FromQuery] Guid especialistaId)
        {
            try
            {
                var service = CreateService();
                var diagnosticoId = new Tuple<Guid, Guid>(citaId, especialistaId);
                service.Delete(diagnosticoId);

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
