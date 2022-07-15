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
    public class PacienteController : ControllerBase
    {
        private PacienteUseCase CreateService(){
            ClinicaDB db = new ClinicaDB();
            PacienteRepository repository = new PacienteRepository(db);
            PacienteUseCase service = new PacienteUseCase(repository);
            return service;
        }

        private UsuarioUseCase CreateServiceUsuario()
        {
            ClinicaDB db = new ClinicaDB();
            UsuarioRepository repository = new UsuarioRepository(db);
            UsuarioUseCase service = new UsuarioUseCase(repository);
            return service;
        }

        // GET: api/<PacienteController>
        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Get()
        {
            PacienteUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<PacienteController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable <Paciente>> Get(Guid id)
        {
            PacienteUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<PacienteController>
        [HttpPost]
        public ActionResult<Paciente> Post([FromBody] Paciente paciente)
        {
            try
            {
                PacienteUseCase service = CreateService();
                var result = service.Create(paciente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    error = "Error: " + ex.Message,
                });
            }
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Paciente paciente)
        {
            PacienteUseCase service = CreateService();
            paciente.pacienteId = id;
            service.Update(paciente);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try {
                PacienteUseCase service = CreateService();
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

        // GET: api/<UsuarioController>
        [HttpGet("posiblesUsuarios")]
        public ActionResult<IEnumerable<Usuario>> PosiblesUsuarios()
        {
            try
            {
                UsuarioUseCase service = CreateServiceUsuario();
                var posiblesUsuarios = service
                    .GetAll()
                    .Where(usuario => usuario.Paciente == null);

                return Ok(posiblesUsuarios.ToList());
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
