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

        public string InicioElecciones(int id_eleccion)
        {
            DataTable resultadoEjecucionSP = dVotaciones.InicioEleccion(id_eleccion);

            return resultadoEjecucionSP != null ? "INICIO DE ELECCIONES SATISFACTORIA" : throw new Exception("Ocurrió un error al iniciar elecciones en método BVotaciones.InicioElecciones(int)");
        }

    }
}
