using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appClinica.Core.Domain.Interfaces;

namespace appClinica.Core.Infraestructure.Repository.Abstract
{
    public interface IDetailRepository<Entity, TransactionId>
        : ICreate<Entity>, ITransaction
    {

        void Cancel(TransactionId transactionId);

        List<Entity> GetDetailsByTransaction(TransactionId transactionId);
    }
}
