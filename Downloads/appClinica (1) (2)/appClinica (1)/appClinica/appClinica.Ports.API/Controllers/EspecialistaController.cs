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
    public class EspecialistaController : ControllerBase
    {
        private EspecialistaUseCase CreateService()
        {
            ClinicaDB db = new ClinicaDB();
            EspecialistaRepository repository = new EspecialistaRepository(db);
            EspecialistaUseCase service = new EspecialistaUseCase(repository);
            return service;
        }

        private UsuarioUseCase CreateServiceUsuario()
        {
            ClinicaDB db = new ClinicaDB();
            UsuarioRepository repository = new UsuarioRepository(db);
            UsuarioUseCase service = new UsuarioUseCase(repository);
            return service;
        }


        // GET: api/<EspecialistaController>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable <Especialista>> Get()
        {
            EspecialistaUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<EspecialistaController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Especialista> Get(Guid id)
        {
            EspecialistaUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<EspecialistaController>
        [HttpPost]
        public ActionResult<Especialista> Post([FromBody] Especialista especialista)
        {
            try
            {
                EspecialistaUseCase service = CreateService();
                var result = service.Create(especialista);
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

        // PUT api/<EspecialistaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Especialista especialista)
        {
            EspecialistaUseCase service = CreateService();
            especialista.especialistaId = id;
            service.Update(especialista);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<EspecialistaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try {
                EspecialistaUseCase service = CreateService();
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
                    .Where(usuario => usuario.Especialista == null);

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
