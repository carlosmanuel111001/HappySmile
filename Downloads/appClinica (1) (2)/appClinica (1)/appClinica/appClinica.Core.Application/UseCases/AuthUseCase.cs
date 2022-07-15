using appClinica.Core.Application.Interfaces;
using appClinica.Core.Domain.Models;
using appClinica.Core.Infraestructure.Repository.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace appClinica.Core.Application.UseCases
{
    public class AuthUseCase
        : IAuthUseCase
    {
        private readonly IAuthRepository<Usuario, string> authRepository;

        public AuthUseCase(IAuthRepository<Usuario, string> authRepository)
        {
            this.authRepository = authRepository;
        }

        public string Login(Usuario usuario, string key)
        {
            var currentUser = authRepository.Login(usuario);
            if (currentUser == null) {
                //throw new Exception("Usuario o contraseña incorrectos");
                return null;
            }

            var token = authRepository.GetToken(usuario, key);
            string result = JsonConvert.SerializeObject(new
            {
                token,
                usuario = currentUser,
            });

            return result;
        }
    }
}
