using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(P=> P.id);
            builder.Property(P=> P.nombre).HasMaxLength(30).IsRequired();
            builder.Property(P => P.apellido).HasMaxLength(30).IsRequired();
            builder.Property(P => P.fecha_nacimiento).IsRequired();
            builder.Property(P => P.telefono).IsRequired().HasMaxLength(9);
            builder.Property(p => p.Email).HasMaxLength(100);
            builder.Property(P => P.Direccion).HasMaxLength(120);
            builder.Property(p => p.Edad);
            builder.Property(P => P.CreatedBy).HasMaxLength(30);
            builder.Property(P => P.LastModifiedBy).HasMaxLength(30);


        }
       
    }
}
