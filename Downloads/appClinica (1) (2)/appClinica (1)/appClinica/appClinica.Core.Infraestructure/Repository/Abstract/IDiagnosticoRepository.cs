using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appClinica.Core.Infraestructure.Repository.Abstract
{
    public interface IDiagnosticoRepository<Entity, EntityId>
        : IBaseRepository<Entity, EntityId>
    {
        List<Entity> GetByCita(Guid citaId);

        List<Entity> GetByEspecialista(Guid especialistaId);
    }
}
