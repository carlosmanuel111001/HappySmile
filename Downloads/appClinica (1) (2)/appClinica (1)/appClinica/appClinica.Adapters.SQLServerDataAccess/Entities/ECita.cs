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
    public class ECita : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("tblCitas");

            builder.HasKey(cita => cita.citaId);

            builder
                .HasOne(cita => cita.Paciente)
                .WithMany(paciente => paciente.Citas);

            builder
                .HasMany(cita => cita.Diagnosticos)
                .WithOne(diagnostico => diagnostico.Cita);
        }
    }
}
