using Elecciones.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elecciones.BLL
{
    public class BVotaciones
    {

        private DVotaciones dVotaciones = new DVotaciones();

        public string BLLGetResultado()
        {
            DataTable resultadoEjecucionSP = dVotaciones.testResultadoDB();

            string res = "";

            foreach (DataRow row in resultadoEjecucionSP.Rows)
            {
                res += " " + row["em_id"].ToString() + " " + row["em_nombre"].ToString();
            }
            return res;
        }

    }
}
