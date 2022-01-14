using Assicurazione.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Repository
{
    internal class RepositoryCliente : IRepositoryCliente
    {
        public Cliente Create(Cliente item)
        {
            using (var ctx = new Context())
            {
                ctx.Clienti.Add(item);
                ctx.SaveChanges();
            }
            return item;

        }
        public ICollection<Cliente> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Clienti.ToList();
            }
        }
        public Cliente GetByCode(string codice)
        {
            return GetAll().FirstOrDefault(e => e.CodiceFiscaleID == codice);
        }
    }
}
