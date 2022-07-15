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
    public class PacienteUseCase : IBaseUseCase<Paciente, Guid>
    {
        private readonly IBaseRepository<Paciente, Guid> repository;

        public PacienteUseCase(IBaseRepository<Paciente, Guid> repository)
        {
            this.repository = repository;
        }

        public Paciente Create(Paciente entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }

            throw new Exception("Error: el paciente no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Paciente> GetAll()
        {
            return repository.GetAll();
        }

        public Paciente GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Paciente Update(Paciente entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
