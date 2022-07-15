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
    public class EspecialistaUseCase : IBaseUseCase<Especialista, Guid>
    {

        private readonly IBaseRepository<Especialista, Guid> repository;

        public EspecialistaUseCase(IBaseRepository<Especialista, Guid> repository)
        {
            this.repository = repository;
        }

        public Especialista Create(Especialista entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }

            throw new Exception("Error: el especialista no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Especialista> GetAll()
        {
            return repository.GetAll();
        }

        public Especialista GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Especialista Update(Especialista entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
