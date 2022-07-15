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
    //public class DiagnosticoUseCase : IDetailUseCase<Cita, Guid>
    //{

    //    private readonly IBaseRepository<Cita, Guid> repository;
    //    private readonly IDetailRepository<Diagnostico, Guid> repositoryDiagnostico;

    //    public DiagnosticoUseCase(IBaseRepository<Cita, Guid> repository, IDetailRepository<Diagnostico, Guid> repositoryDiagnostico)
    //    {
    //        this.repository = repository;
    //        this.repositoryDiagnostico = repositoryDiagnostico;
    //    }

    //    public void Cancel(Guid entityId)
    //    {
    //        repositoryDiagnostico.Cancel(entityId);
    //        repository.SaveAllChanges();
    //    }

    //    public Cita Create(Cita entity)
    //    {
    //        var citaCreada = repository.Create(entity);
    //        citaCreada.Diagnosticos.ForEach(diagnostico => {
    //            repositoryDiagnostico.Create(diagnostico);
    //        });

    //        repository.SaveAllChanges();

    //        return citaCreada;
    //    }
    //}

    public class DiagnosticoUseCase
        : IDiagnosticoUseCase<Diagnostico, Tuple<Guid, Guid>> {
        private readonly IDiagnosticoRepository<Diagnostico, Tuple<Guid, Guid>> repository;

        public DiagnosticoUseCase(IDiagnosticoRepository<Diagnostico, Tuple<Guid, Guid>> repository)
        {
            this.repository = repository;
        }

        public Diagnostico Create(Diagnostico entity)
        {
            if (entity != null) {
                var result = repository.Create(entity);
                entity.fechaDiagnostico = DateTime.Now;
                repository.SaveAllChanges();
                return result;
            }

            throw new Exception("Error: el Diagnostico no puede ser nulo");
        }

        public void Delete(Tuple<Guid, Guid> entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Diagnostico> GetAll()
        {
            return repository.GetAll();
        }

        public List<Diagnostico> GetByCita(Guid citaId)
        {
            return repository.GetByCita(citaId);
        }

        public List<Diagnostico> GetByEspecialista(Guid especialistaId)
        {
            return repository.GetByEspecialista(especialistaId);
        }

        public Diagnostico GetById(Tuple<Guid, Guid> entityId)
        {
            return repository.GetById(entityId);
        }

        public Diagnostico Update(Diagnostico entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
