using Assicurazione.Configuration;
using Assicurazione.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione
{
    public class Context : DbContext
    {

        public DbSet<Polizza> Polizze { get; set; }
        public DbSet<Cliente> Clienti { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PolizzeAssicurative;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Polizza>(new PolizzaConfiguration());
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            

        }

    }
}
