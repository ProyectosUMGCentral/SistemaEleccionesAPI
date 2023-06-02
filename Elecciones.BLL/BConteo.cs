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
    public class BConteo
    {

        private readonly DConteo dConteo = new DConteo();

        public ResultadoConteoVotosDTO GetConteoVotos(int? centro_votacion)
        {
            DataTable resultadoEjecucionSP = dConteo.CantidadVotos(centro_votacion);
            if (resultadoEjecucionSP.Rows.Count != 1) throw new Exception("Ocurrio un error al consultar la cantidad de votos");

            DataRow GetDataFirstRow = resultadoEjecucionSP.Rows[0];

            return new ResultadoConteoVotosDTO()
            {
                Cantidad_Votos = Convert.ToInt32(GetDataFirstRow["Cantidad-Votos"])
            };
        }

        public ResultadoPorcentajeCentroVotacionDTO PorcentajeCentroVotacion(int centro_votacion)
        {
            DataTable resultadoEjecucionSP = dConteo.PorcentajeCV(centro_votacion);
            if (resultadoEjecucionSP.Rows.Count != 1) throw new Exception("Ocurrio un error al consultar el porcentaje de votos");

            DataRow GetDataFirstRow = resultadoEjecucionSP.Rows[0];

            return new ResultadoPorcentajeCentroVotacionDTO()
            {
                Porcentaje = Math.Round(Convert.ToDouble(GetDataFirstRow["Porcentaje"]), 2)
            };
        }

    }
}
