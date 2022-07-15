using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace appClinica.Core.Domain.Models
{
    public class Cita
    {
        public Guid citaId { get; set; }

        public DateTime fechaRegistro { get; set; }

        public DateTime fechaVisita { get; set; }

        public string sintomas { get; set; }

        public Guid especialistaId { get; set; }

        public Guid pacienteId { get; set; }

        [ForeignKey("pacienteId")]
        public Paciente Paciente { get; set; }

        public List<Diagnostico> Diagnosticos { get; set; }
    }
}
