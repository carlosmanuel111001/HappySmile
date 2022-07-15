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
    public class EspecialistaRepository : IBaseRepository<Especialista, Guid>
    {

        private ClinicaDB db;

        public EspecialistaRepository(ClinicaDB db)
        {
            this.db = db;
        }

        public Especialista Create(Especialista entity)
        {
            entity.especialistaId = Guid.NewGuid();
            db.Especialistas.Add(entity);
            return entity;
        }

        public void Delete(Guid entityId)
        {
            var especialistaSeleccionado = db.Especialistas
                .Where(c => c.especialistaId == entityId)
                .FirstOrDefault();

            if (especialistaSeleccionado != null)
            {
                db.Especialistas.Remove(especialistaSeleccionado);
            }
        }

        public List<Especialista> GetAll()
        {
            return db.Especialistas.ToList();
        }

        public Especialista GetById(Guid entityId)
        {
            var especialistaSeleccionado = db.Especialistas
                .Where(c => c.especialistaId == entityId)
                .FirstOrDefault();

            return especialistaSeleccionado;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Especialista Update(Especialista entity)
        {
            var especialistaSeleccionado = db.Especialistas
                .Where(c => c.especialistaId == entity.especialistaId)
                .FirstOrDefault();

            if (especialistaSeleccionado != null)
            {
                especialistaSeleccionado.nombres = entity.nombres;
                especialistaSeleccionado.apellidos = entity.apellidos;
                especialistaSeleccionado.especialidad = entity.especialidad;
                especialistaSeleccionado.bandera = entity.bandera;
            }

            return especialistaSeleccionado;
        }
    }
}
