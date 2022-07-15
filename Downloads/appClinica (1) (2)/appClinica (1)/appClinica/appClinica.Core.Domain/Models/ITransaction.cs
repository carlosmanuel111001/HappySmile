using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appClinica.Core.Domain.Interfaces
{
    public interface ITransaction
    {
        void SaveAllChanges();
    }
}
