using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace appClinica.Core.Domain.Models
{
    public class Usuario
    {
        public Guid usuarioId { get; set; }

        public string correo { get; set; }

        [JsonIgnore]
        public string contraseña { get; set; }

        public bool bandera { get; set; }

        [JsonIgnore]
        public Especialista Especialista { get; set; }

        [JsonIgnore]
        public Paciente Paciente { get; set; }
    }
}
