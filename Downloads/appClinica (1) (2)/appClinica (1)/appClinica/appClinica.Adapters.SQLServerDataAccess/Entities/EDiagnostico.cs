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
    public class EDiagnostico : IEntityTypeConfiguration<Diagnostico>
    {
        public void Configure(EntityTypeBuilder<Diagnostico> builder)
        {
            builder.ToTable("tblDiagnosticos");

            builder.HasKey(diagnostico => new { diagnostico.especialistaId, diagnostico.citaId });

            builder
                .HasOne(diagnostico => diagnostico.Especialista)
                .WithMany(especialista => especialista.Diagnosticos)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(diagnostico => diagnostico.Cita)
                .WithMany(cita => cita.Diagnosticos)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
