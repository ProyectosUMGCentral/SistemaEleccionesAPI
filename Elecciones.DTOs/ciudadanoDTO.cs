using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DTOs
{
    public class ciudadanoDTO
    {
        public int ec_id { get; set; }
        public int eti_id { get; set; }
        public int em_id { get; set; }
        public string ec_num_identificacion { get; set; }
        public string ec_nombre1 { get; set; }
        public string ec_nombre2 { get; set; }
        public string ec_nombre3 { get; set; }
        public string ec_apellido1 { get; set; }
        public string ec_apellido2 { get; set; }
        public string ec_apellido3 { get; set; }
        public DateTime ec_fecha_nac { get; set; }
        public string ec_correo_electronico { get; set; }
        public string ec_num_tel { get; set; }

    }
}
