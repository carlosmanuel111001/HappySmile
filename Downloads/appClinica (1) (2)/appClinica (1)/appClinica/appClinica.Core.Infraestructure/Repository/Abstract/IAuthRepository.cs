using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appClinica.Core.Infraestructure.Repository.Abstract
{
    public interface IAuthRepository<Entity, Key>
    {
        Entity Login(Entity entity);

        string GetToken(Entity entity, Key key);
    }
}
