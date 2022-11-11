using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Enumerables;

namespace Servicios
{
    public class Usuarios
    {

        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public Entidades.Enumerables.TipoUsuario TipoUsuario { get; set;}


        public static List<Usuarios> Listar()

        {
            string listaUsuariosJson = new Rest("https://6334ca62ea0de5318a09032d.mockapi.io/Clientes").CreateObject();
            List<Usuarios> listaUsuarios = JsonConvert.DeserializeObject<List<Usuarios>>(listaUsuariosJson);



            return listaUsuarios;

        }
    }
}