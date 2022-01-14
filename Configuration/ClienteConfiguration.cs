using Assicurazione.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assicurazione.Configuration
{
    public class ClienteConfiguration: IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.Property(c => c.CodiceFiscaleID).IsFixedLength().HasMaxLength(16);
            builder.HasKey(k => k.CodiceFiscaleID);
            builder.Property(c => c.Nome).IsRequired().IsFixedLength().HasMaxLength(20); ;
            builder.Property(c => c.Indirizzo).IsRequired().IsFixedLength().HasMaxLength(20); ;


            builder.HasMany(e => e.Polizze).WithOne(e => e.Cliente).HasForeignKey(e => e.CodiceFiscaleID);
        }

    }
}
