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
    public class UsuarioUseCase : IBaseUseCase<Usuario, Guid>
    {
        private readonly IBaseRepository<Usuario, Guid> repository;

        public UsuarioUseCase(IBaseRepository<Usuario, Guid> repository) {
            this.repository = repository;
        }

        public Usuario Create(Usuario entity)
        {
            if (entity != null) {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }

            throw new Exception("Error: el usuario no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Usuario> GetAll()
        {
            return repository.GetAll();
        }

        public Usuario GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Usuario Update(Usuario entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
