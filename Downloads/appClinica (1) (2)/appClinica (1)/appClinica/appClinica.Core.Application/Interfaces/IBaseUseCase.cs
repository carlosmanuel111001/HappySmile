using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appClinica.Core.Domain.Interfaces;

namespace appClinica.Core.Application.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId>
        : ICreate<Entity>, IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {



    }
}
