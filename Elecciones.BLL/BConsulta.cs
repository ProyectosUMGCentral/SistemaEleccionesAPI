using Elecciones.DAL;
using Elecciones.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.BLL
{
    public class BConsulta
    {
        private readonly DConsultasDB DConsultasDB = new DConsultasDB();
        public ciudadanoDTO GetCiudadano(string identificacion)
        {
            DataTable resultadoEjecucionSP = DConsultasDB.consultaCiudadano(identificacion);
            if (resultadoEjecucionSP.Rows.Count != 1) throw new Exception("No se encontro al ciudadano");

            DataRow GetDataFirstRow = resultadoEjecucionSP.Rows[0];

            //Cantidad_Votos = Convert.ToInt32(GetDataFirstRow["Cantidad-Votos"])

            return new ciudadanoDTO()
            {
                ec_id = Convert.ToInt32(GetDataFirstRow["ec_id"]),
                eti_id = Convert.ToInt32(GetDataFirstRow["eti_id"]),
                em_id = Convert.ToInt32(GetDataFirstRow["em_id"]),
                ec_num_identificacion = Convert.ToString(GetDataFirstRow["ec_num_identificacion"]),
                ec_nombre1 = Convert.ToString(GetDataFirstRow["ec_nombre1"]),
                ec_nombre2 = Convert.ToString(GetDataFirstRow["ec_nombre2"]),
                ec_nombre3 = Convert.ToString(GetDataFirstRow["ec_nombre3"]),
                ec_apellido1 = Convert.ToString(GetDataFirstRow["ec_apellido1"]),
                ec_apellido2 = Convert.ToString(GetDataFirstRow["ec_apellido2"]),
                ec_apellido3 = Convert.ToString(GetDataFirstRow["ec_apellido3"]),
                ec_fecha_nac = Convert.ToDateTime(GetDataFirstRow["ec_fecha_nac"]),
                ec_correo_electronico = Convert.ToString(GetDataFirstRow["ec_correo_electronico"]),
                ec_num_tel = Convert.ToString(GetDataFirstRow["ec_num_tel"]),
            };
        }
    }
}
