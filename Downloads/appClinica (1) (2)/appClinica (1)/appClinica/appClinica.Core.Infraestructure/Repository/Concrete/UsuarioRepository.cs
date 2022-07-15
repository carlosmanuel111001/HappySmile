using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appClinica.Core.Domain.Models;
using appClinica.Core.Infraestructure.Repository.Abstract;
using appClinica.Adapters.SQLServerDataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace appClinica.Core.Infraestructure.Repository.Concrete
{
    public class UsuarioRepository : IBaseRepository<Usuario, Guid>
    {

        private ClinicaDB db;

        public UsuarioRepository(ClinicaDB db) {
            this.db = db;
        }

        public Usuario Create(Usuario entity)
        {
            entity.usuarioId = Guid.NewGuid();
            db.Usuarios.Add(entity);
            return entity;
        }

        public void Delete(Guid entityId)
        {
            var usuarioSeleccionado = db.Usuarios
                .Where(c => c.usuarioId == entityId)
                .FirstOrDefault();

            if(usuarioSeleccionado != null)
            {
                db.Usuarios.Remove(usuarioSeleccionado);
            }
        }

        public List<Usuario> GetAll()
        {
            var usuarios = db.Usuarios.ToList();
            foreach (var usuario in usuarios) {
                var paciente = db.Pacientes
                    .Where(p => p.usuarioId == usuario.usuarioId)
                    .FirstOrDefault();
                if (paciente != null) {
                    usuario.Paciente = new Paciente();
                    usuario.Paciente.pacienteId = paciente.pacienteId;
                    usuario.Paciente.nombres = paciente.nombres;
                    usuario.Paciente.apellidos = paciente.apellidos;
                    usuario.Paciente.fechaNacimiento = paciente.fechaNacimiento;
                }

                var especialista = db.Especialistas
                    .Where(e => e.usuarioId == usuario.usuarioId)
                    .FirstOrDefault();
                if (especialista != null)
                {
                    usuario.Especialista = new Especialista();
                    usuario.Especialista.especialistaId = especialista.especialistaId;
                    usuario.Especialista.nombres = especialista.nombres;
                    usuario.Especialista.apellidos = especialista.apellidos;
                    usuario.Especialista.especialidad = especialista.especialidad;
                }
            }
            return usuarios.ToList();
        }

        public Usuario GetById(Guid entityId)
        {
            var usuarioSeleccionado = db.Usuarios
                .Where(c => c.usuarioId == entityId)
                .FirstOrDefault();

            return usuarioSeleccionado;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Usuario Update(Usuario entity)
        {
            var usuarioSeleccionado = db.Usuarios
                .Where(c => c.usuarioId == entity.usuarioId)
                .FirstOrDefault();

            if (usuarioSeleccionado != null)
            {
                usuarioSeleccionado.correo = entity.correo;
                usuarioSeleccionado.contraseña = entity.contraseña;
                usuarioSeleccionado.bandera = entity.bandera;
            }

            return usuarioSeleccionado;
        }
    }
}
