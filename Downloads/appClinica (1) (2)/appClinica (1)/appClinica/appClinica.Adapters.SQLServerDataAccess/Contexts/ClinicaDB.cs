using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using appClinica.Core.Domain.Models;
using appClinica.Adapters.SQLServerDataAccess.Entities;
using appClinica.Adapters.SQLServerDataAccess.Utils;

namespace appClinica.Adapters.SQLServerDataAccess.Contexts
{
    public class ClinicaDB : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Especialista> Especialistas { get; set; }

        public DbSet<Cita> Citas { get; set; }

        public DbSet<Diagnostico> Diagnosticos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EUsuario());
            builder.ApplyConfiguration(new EPaciente());
            builder.ApplyConfiguration(new EEspecialista());
            builder.ApplyConfiguration(new ECita());
            builder.ApplyConfiguration(new EDiagnostico());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer(GlobalSettings.SqlServerConnectionString);
        }

    }
}
