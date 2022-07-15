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
    public class UsuarioController : ControllerBase
    {

        private UsuarioUseCase CreateService() {
            ClinicaDB db = new ClinicaDB();
            UsuarioRepository repository = new UsuarioRepository(db);
            UsuarioUseCase service = new UsuarioUseCase(repository);
            return service;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            UsuarioUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(Guid id)
        {
            UsuarioUseCase service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            UsuarioUseCase service = CreateService();
            usuario.bandera = false;
            var result = service.Create(usuario);
            return Ok(result);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            UsuarioUseCase service = CreateService();
            usuario.usuarioId = id;
            service.Update(usuario);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                UsuarioUseCase service = CreateService();
                service.Delete(id);

                return Ok(new {
                    message = "Eliminado exitosamente",
                });
            }
            catch (Exception ex) {
                return Ok(new {
                    error = "Error: " + ex.Message,
                });
            }
        }
    }
}
