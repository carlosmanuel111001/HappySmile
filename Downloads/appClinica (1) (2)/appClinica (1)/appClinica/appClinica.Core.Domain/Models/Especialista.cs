using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace appClinica.Core.Domain.Models
{
    public class Especialista
    {
        public Guid especialistaId { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string especialidad { get; set; }

        public bool bandera { get; set; }

        public Guid usuarioId { get; set; }

        [ForeignKey("usuarioId")]
        public Usuario Usuario { get; set; }

        [JsonIgnore]
        public List<Diagnostico> Diagnosticos { get; set; }

        
    }
}
