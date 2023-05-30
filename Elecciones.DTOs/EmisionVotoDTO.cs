using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DTOs
{
    public class EmisionVotoDTO
    {
        public string num_identificacion { get; set; }
        public int centro_votacion { get; set; }
        public int terminal_voto { get; set; }
        public int candidato { get; set; }
        public int eleccion { get; set; }
        public int autoridad_mesa { get; set; }
    }
}
