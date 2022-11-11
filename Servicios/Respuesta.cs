using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Respuesta
    {
            public int Codigo { get; set; }
            public string Mensaje { get; set; }
            public bool esCorrecto { get; set; }
            public object Objeto { get; set; }

        
    }
}
