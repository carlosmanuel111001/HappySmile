using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using appClinica.Core.Domain.Models;
using appClinica.Core.Infraestructure.Repository.Abstract;
using appClinica.Adapters.SQLServerDataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace appClinica.Core.Infraestructure.Repository.Concrete
{
    public class DiagnosticoRepository : IDiagnosticoRepository<Diagnostico, Tuple<Guid, Guid>> {
        private ClinicaDB db;

        public DiagnosticoRepository(ClinicaDB db) {
            this.db = db;
        }

        public Diagnostico Create(Diagnostico entity)
        {
            db.Diagnosticos.Add(entity);
            return entity;
        }

        public void Delete(Tuple<Guid, Guid> entityId)
        {
            var diagnosticoSeleccionado = db.Diagnosticos
                .Where(c => c.citaId == entityId.Item1 && c.especialistaId == entityId.Item2)
                .FirstOrDefault();

            if (diagnosticoSeleccionado != null)
            {
                db.Diagnosticos.Remove(diagnosticoSeleccionado);
            }
        }

        public List<Diagnostico> GetAll()
        {
            var diagnosticos = db.Diagnosticos
                .Include(c => c.Cita)
                .Include(c => c.Cita.Paciente)
                .Include(c => c.Especialista)
                .ToList();
            foreach (var diagnostico in diagnosticos) {
                var prevCita = diagnostico.Cita;

                diagnostico.Cita = new Cita() {
                    Paciente = new Paciente() {
                        nombres = prevCita?.Paciente?.nombres,
                        apellidos = prevCita?.Paciente?.apellidos,
                    },
                    fechaVisita = prevCita?.fechaVisita ?? DateTime.Now,
                    sintomas = prevCita?.sintomas,
                };

                var prevEspecialista = diagnostico.Especialista;
                diagnostico.Especialista = new Especialista() {
                    nombres = prevEspecialista?.nombres,
                    apellidos = prevEspecialista?.apellidos,
                };
            }
            return diagnosticos;
        }

        public List<Diagnostico> GetByCita(Guid citaId)
        {
            return db.Diagnosticos
                .Where(c => c.citaId == citaId)
                .ToList();
        }

        public List<Diagnostico> GetByEspecialista(Guid especialistaId)
        {
            return db.Diagnosticos
                .Where(c => c.especialistaId == especialistaId)
                .ToList();
        }

        public Diagnostico GetById(Tuple<Guid, Guid> entityId)
        {
            var diagnosticoSeleccionado = db.Diagnosticos
                .Where(c => c.citaId == entityId.Item1 && c.especialistaId == entityId.Item2)
                .FirstOrDefault();

            return diagnosticoSeleccionado;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Diagnostico Update(Diagnostico entity)
        {
            var diagnosticoSeleccionado = db.Diagnosticos
                .Where(c => c.citaId == entity.citaId && c.especialistaId == entity.especialistaId)
                .FirstOrDefault();

            if (diagnosticoSeleccionado != null)
            {
                diagnosticoSeleccionado.fechaDiagnostico = entity.fechaDiagnostico;
                diagnosticoSeleccionado.descripcionDiagnostico = entity.descripcionDiagnostico;
                diagnosticoSeleccionado.descripcionMalestar = entity.descripcionMalestar;
                diagnosticoSeleccionado.estadoDiagnostico = entity.estadoDiagnostico;
                diagnosticoSeleccionado.especialistaId = entity.especialistaId;
            }

            return diagnosticoSeleccionado;
        }
    }
}
