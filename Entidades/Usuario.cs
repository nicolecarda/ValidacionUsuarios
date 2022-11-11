using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Apellido")]
        public string Apellido { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Clave")]
        public string Clave { get; set; }

        [JsonProperty("IdTipoUsuario")]
        public long IdTipoUsuario { get; set; }

        [JsonProperty("Estado")]
        public bool Estado { get; set; }

        [JsonProperty("UrlPerfil")]
        public string UrlPerfil { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

    }
}
