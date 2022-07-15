using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appClinica.Core.Application.Interfaces
{
    public interface IDiagnosticoUseCase<Entity, EntityId>
        : IBaseUseCase<Entity, EntityId>
    {
        List<Entity> GetByCita(Guid citaId);

        List<Entity> GetByEspecialista(Guid especialistaId);
    }
}
