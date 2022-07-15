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
    public class EPaciente : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("tblPacientes");

            builder.HasKey(paciente => paciente.pacienteId);

            builder
                .HasOne(paciente => paciente.Usuario)
                .WithOne(usuario => usuario.Paciente);

            builder
                .HasMany(paciente => paciente.Citas)
                .WithOne(cita => cita.Paciente);
        }
    }
}
