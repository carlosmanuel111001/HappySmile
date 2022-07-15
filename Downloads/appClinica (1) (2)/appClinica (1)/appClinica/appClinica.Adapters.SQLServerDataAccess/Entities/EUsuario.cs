using appClinica.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appClinica.Adapters.SQLServerDataAccess.Entities
{
    public class EUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tblUsuarios");
            builder.HasKey(usuario => usuario.usuarioId);

            builder
                .HasOne(usuario => usuario.Paciente)
                .WithOne(paciente => paciente.Usuario)
                .HasForeignKey<Paciente>(paciente => paciente.usuarioId);

            builder
                .HasOne(usuario => usuario.Especialista)
                .WithOne(especialista => especialista.Usuario)
                .HasForeignKey<Especialista>(especialista => especialista.usuarioId);
        }
    }
}
