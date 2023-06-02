using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.DTOs
{
    public class consultaCandidatosDTO
    {
        public int? cargo { get; set; }
        public int? municipio { get; set; }
        public int? departamento { get; set; }
    }
    public class CandidatosDTO
    {
        public int eca_id {get; set;}
	    public string eca_nombre_Cargo {get; set;}
	    public string eca_descripcion {get; set;}
		public int ec_id {get; set;}
		public string ec_num_identificacion {get; set;}
		public string ec_nombre1 {get; set;}
		public string ec_nombre2 {get; set;}
		public string ec_nombre3 {get; set;}
		public string ec_apellido1 {get; set;}
		public string ec_apellido2 {get; set;}
		public string ec_apellido3 {get; set;}
		public DateTime ec_fecha_nac {get; set;}
		public string ec_correo_electronico {get; set;}
		public string ec_num_tel {get; set;} 
		public int em_id {get; set;}
		public string em_nombre {get; set;}
		public int ee_id {get; set;}
		public string ee_nombre { get; set; }
    }
}
