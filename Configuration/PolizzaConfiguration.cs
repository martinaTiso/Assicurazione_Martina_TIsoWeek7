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
    internal class PolizzaConfiguration : IEntityTypeConfiguration<Polizza>
    {
        public void Configure(EntityTypeBuilder<Polizza> builder)
        {
            builder.ToTable("Polizza");
            builder.HasKey(k => k.NumeroID);
            builder.Property(c => c.DataStipula).IsRequired();
            builder.Property(c => c.ImportoAssicurato).IsRequired();
            builder.Property(c => c.RataMensile).IsRequired();


            builder.HasOne(e => e.Cliente).WithMany(s => s.Polizze).HasForeignKey(s => s.NumeroID).HasConstraintName("Fk_Cliente");

            builder.HasDiscriminator<string>("polizza_type")
                  .HasValue<Polizza>("polizza")
                  .HasValue<RCauto>("rcauto")
                  .HasValue<Vita>("vita")
                  .HasValue<Furto>("furto");

        }

    }
}
