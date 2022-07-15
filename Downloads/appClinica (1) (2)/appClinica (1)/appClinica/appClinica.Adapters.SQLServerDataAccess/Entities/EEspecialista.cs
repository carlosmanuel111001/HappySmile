using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appClinica.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace appClinica.Adapters.SQLServerDataAccess.Entities
{
    public class EEspecialista : IEntityTypeConfiguration<Especialista>
    {
        public void Configure(EntityTypeBuilder<Especialista> builder)
        {
            builder.ToTable("tblEspecialistas");

            builder.HasKey(especialista => especialista.especialistaId);

            builder
                .HasOne(especialista => especialista.Usuario)
                .WithOne(usuario => usuario.Especialista);

            builder
                .HasMany(especialista => especialista.Diagnosticos)
                .WithOne(diagnostico => diagnostico.Especialista);
        }
    }
}
