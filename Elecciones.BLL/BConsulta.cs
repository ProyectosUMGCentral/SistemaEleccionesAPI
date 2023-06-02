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
                ee_id = Convert.ToInt32(GetDataFirstRow["ee_id"])
            };
        }
        public usuarioDTO GetUsuario(string email, string passWord)
        {
            DataTable resultadoEjecucionSP = DConsultasDB.consultaUsuario(email, passWord);
            if (resultadoEjecucionSP.Rows.Count != 1) throw new Exception("No se encontro el usuario");

            DataRow GetDataFirstRow = resultadoEjecucionSP.Rows[0];

            return new usuarioDTO()
            {
                eu_id = Convert.ToInt32(GetDataFirstRow["eu_id"]),
                eu_email = Convert.ToString(GetDataFirstRow["eu_email"])
            };
        }
        public List<CandidatosDTO> GetCandidatos(consultaCandidatosDTO candidato)
        {
            DataTable resultadoEjecucionSP = DConsultasDB.consultaCandidato(candidato);
            if (resultadoEjecucionSP.Rows?.Count == 0) throw new Exception("No se encontraron candidatos");

            List<CandidatosDTO> result = new List<CandidatosDTO>();

            foreach (DataRow row in resultadoEjecucionSP.Rows) 
            {
                result.Add(new CandidatosDTO()
                {
                    eca_id = Convert.ToInt32(row["eca_id"]),
                    eca_nombre_Cargo = Convert.ToString(row["eca_nombre_Cargo"]),
                    eca_descripcion = Convert.ToString(row["eca_descripcion"]),
                    ec_id = Convert.ToInt32(row["ec_id"]),
                    ec_num_identificacion = Convert.ToString(row["ec_num_identificacion"]),
                    ec_nombre1 = Convert.ToString(row["ec_nombre1"]),
                    ec_nombre2 = Convert.ToString(row["ec_nombre2"]),
                    ec_nombre3 = Convert.ToString(row["ec_nombre3"]),
                    ec_apellido1 = Convert.ToString(row["ec_apellido1"]),
                    ec_apellido2 = Convert.ToString(row["ec_apellido2"]),
                    ec_apellido3 = Convert.ToString(row["ec_apellido3"]),
                    ec_fecha_nac = Convert.ToDateTime(row["ec_fecha_nac"]),
                    ec_correo_electronico = Convert.ToString(row["ec_correo_electronico"]),
                    ec_num_tel = Convert.ToString(row["ec_num_tel"]),
                    em_id = Convert.ToInt32(row["em_id"]),
                    em_nombre = Convert.ToString(row["em_nombre"]),
                    ee_id = Convert.ToInt32(row["ee_id"]),
                    ee_nombre = Convert.ToString(row["ee_nombre"]),
                });
            }

            return result;
        }
    }
}
