using Assicurazione.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Repository
{
    internal class RepositoryPolizza : IRepositoryPolizza
    {
        public Polizza Create(Polizza item)
        {
            using (var ctx = new Context())
            {
                ctx.Polizze.Add(item);
                ctx.SaveChanges();
            }
            return item;

        }
        public ICollection<Polizza> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Polizze.Include(p => p.Cliente).ToList();
            }
        }

    }
}
