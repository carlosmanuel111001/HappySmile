using appClinica.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appClinica.Core.Application.Interfaces
{
    public interface IAuthUseCase
    {
        string Login(Usuario usuario, string key);
    }
}
