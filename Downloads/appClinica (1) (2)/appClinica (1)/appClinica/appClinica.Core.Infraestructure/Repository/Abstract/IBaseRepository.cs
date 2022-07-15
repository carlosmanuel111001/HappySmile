using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appClinica.Core.Domain.Interfaces;

namespace appClinica.Core.Infraestructure.Repository.Abstract
{
    public interface IBaseRepository<Entity, EntityId>
        : ICreate<Entity>, IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>, ITransaction
    {
        
    }
}
