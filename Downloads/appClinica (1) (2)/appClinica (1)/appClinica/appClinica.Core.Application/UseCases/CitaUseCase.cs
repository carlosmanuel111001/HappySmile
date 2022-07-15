using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appClinica.Core.Domain.Models;
using appClinica.Core.Application.Interfaces;
using appClinica.Core.Infraestructure.Repository.Abstract;

namespace appClinica.Core.Application.UseCases
{
    public class CitaUseCase : IBaseUseCase<Cita, Guid>
    {

        private readonly IBaseRepository<Cita, Guid> repository;

        public CitaUseCase(IBaseRepository<Cita, Guid> repository)
        {
            this.repository = repository;
        }

        public Cita Create(Cita entity)
        {
            if (entity != null)
            {
                entity.fechaRegistro = DateTime.Now;
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }

            throw new Exception("Error: la Cita no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Cita> GetAll()
        {
            return repository.GetAll();
        }

        public Cita GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Cita Update(Cita entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
