using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;

using appClinica.Adapters.SQLServerDataAccess.Contexts;
using appClinica.Core.Infraestructure.Repository.Concrete;
using appClinica.Core.Application.UseCases;
using appClinica.Core.Domain.Models;

using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace appClinica.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ILogger<AuthController> logger;
        private readonly IConfiguration configuration;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration;
        }

        public AuthUseCase CreateService()
        {
            ClinicaDB db = new ClinicaDB();
            AuthRepository repository = new AuthRepository(db);
            AuthUseCase service = new AuthUseCase(repository);
            return service;
        }

        [AllowAnonymous]
        [HttpGet]
        public object Get()
        {
            var responseObject = new { Status = "Running" };
            logger.LogInformation($"Status: {responseObject.Status}");

            return responseObject;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            var service = CreateService();
            var auth = service.Login(usuario, configuration["JWT:Secret"]);

            if (auth == null)
            {
                return Ok(new {
                    error = "Usuario o contraseña incorrectos"
                });
            }

            return Ok(JsonConvert.DeserializeObject(auth));
        }
    }
}
