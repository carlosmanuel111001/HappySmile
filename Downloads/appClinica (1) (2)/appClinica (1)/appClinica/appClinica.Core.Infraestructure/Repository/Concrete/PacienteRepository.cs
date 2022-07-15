using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appClinica.Core.Domain.Models;
using appClinica.Core.Infraestructure.Repository.Abstract;
using appClinica.Adapters.SQLServerDataAccess.Contexts;

namespace appClinica.Core.Infraestructure.Repository.Concrete
{
    public class PacienteRepository : IBaseRepository<Paciente, Guid>
    {

        private ClinicaDB db;

        public PacienteRepository(ClinicaDB db)
        {
            this.db = db;
        }

        public Paciente Create(Paciente entity)
        {
            entity.pacienteId = Guid.NewGuid();
            db.Pacientes.Add(entity);
            return entity;
        }

        public void Delete(Guid entityId)
        {
            var pacienteSeleccionado = db.Pacientes
                .Where(c => c.pacienteId == entityId)
                .FirstOrDefault();

            if (pacienteSeleccionado != null)
            {
                db.Pacientes.Remove(pacienteSeleccionado);
            }
        }

        public List<Paciente> GetAll()
        {
            return db.Pacientes.ToList();
        }

        public Paciente GetById(Guid entityId)
        {
            var pacienteSeleccionado = db.Pacientes
                .Where(c => c.pacienteId == entityId)
                .FirstOrDefault();

            return pacienteSeleccionado;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Paciente Update(Paciente entity)
        {
            var pacienteSeleccionado = db.Pacientes
                .Where(c => c.pacienteId == entity.pacienteId)
                .FirstOrDefault();

            if (pacienteSeleccionado != null)
            {
                pacienteSeleccionado.nombres = entity.nombres;
                pacienteSeleccionado.apellidos = entity.apellidos;
                pacienteSeleccionado.sexo = entity.sexo;
                pacienteSeleccionado.fechaNacimiento = entity.fechaNacimiento;
                pacienteSeleccionado.bandera = entity.bandera;
            }

            return pacienteSeleccionado;
        }
    }
}
