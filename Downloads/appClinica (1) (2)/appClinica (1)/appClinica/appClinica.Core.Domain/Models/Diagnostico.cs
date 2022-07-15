using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace appClinica.Core.Domain.Models
{
    public class Diagnostico
    {
        public Guid especialistaId { get; set; }

        public Guid citaId { get; set; }

        public DateTime fechaDiagnostico { get; set; }

        public string descripcionMalestar { get; set; }

        public string descripcionDiagnostico { get; set; }

        public bool estadoDiagnostico { get; set; }

        [JsonIgnore]
        [ForeignKey("citaId")]
        public Cita Cita { get; set; }

        [ForeignKey("especialistaId")]
        [JsonIgnore]
        public Especialista Especialista { get; set; }
    }
}
