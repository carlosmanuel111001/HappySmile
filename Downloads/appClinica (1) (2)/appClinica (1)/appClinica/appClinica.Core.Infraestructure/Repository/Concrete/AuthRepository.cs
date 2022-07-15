using appClinica.Core.Domain.Models;
using appClinica.Core.Infraestructure.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appClinica.Adapters.SQLServerDataAccess.Contexts;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace appClinica.Core.Infraestructure.Repository.Concrete
{
    public class AuthRepository
        : IAuthRepository<Usuario, string>
    {
        private ClinicaDB db;

        public AuthRepository(ClinicaDB db) {
            this.db = db;
        }
        public string GetToken(Usuario entity, string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, entity.correo)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Usuario Login(Usuario entity)
        {
            var currentUser = db.Usuarios
                .Where(u => u.correo == entity.correo && u.contraseña == entity.contraseña)
                .Include(u => u.Paciente)
                .Include(u => u.Especialista)
                .FirstOrDefault();

            if (currentUser == null) {
                return null;
            }

            if (currentUser.Paciente != null) {
                var prevPaciente = currentUser.Paciente;
                var newPaciente = new Paciente();
                newPaciente.pacienteId = prevPaciente.pacienteId;
                newPaciente.nombres = prevPaciente.nombres;
                newPaciente.apellidos = prevPaciente.apellidos;
                newPaciente.bandera = prevPaciente.bandera;
                newPaciente.fechaNacimiento = prevPaciente.fechaNacimiento;

                currentUser.Paciente = newPaciente;
            }

            if (currentUser.Especialista != null)
            {
                var prevEspecialista = currentUser.Especialista;
                var newEspecialista = new Especialista();
                newEspecialista.especialistaId = prevEspecialista.especialistaId;
                newEspecialista.nombres = prevEspecialista.nombres;
                newEspecialista.apellidos = prevEspecialista.apellidos;
                newEspecialista.bandera = prevEspecialista.bandera;
                newEspecialista.especialidad = prevEspecialista.especialidad;

                currentUser.Especialista = newEspecialista;
            }

            return currentUser;
        }
    }
}
