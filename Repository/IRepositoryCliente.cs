using Assicurazione.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Repository
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        public Cliente GetByCode(string code);
     
    }
}
