using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appClinica.Core.Domain.Interfaces;

namespace appClinica.Core.Application.Interfaces
{
    internal interface IDetailUseCase<Entity, EntityId> : ICreate<Entity>
    {
        void Cancel(EntityId entityId);
    }
}
