using Elecciones.BEL;
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

        private readonly DVotaciones dVotaciones = new DVotaciones();

        public string InicioElecciones(int id_eleccion)
        {
            DataTable resultadoEjecucionSP = dVotaciones.InicioEleccion(id_eleccion);

            return resultadoEjecucionSP != null ? "INICIO DE ELECCIONES SATISFACTORIA" : throw new Exception("Ocurrió un error al iniciar elecciones en método BVotaciones.InicioElecciones(int)");
        }

        public string EmitirVoto(EEmisionVoto emisionVotoDTO)
        {
            if(emisionVotoDTO == null) throw new Exception("Payload es mandatorio!");
            DataTable emisionVotoSP = dVotaciones.EmitirVoto(emisionVotoDTO);
            return emisionVotoSP != null ? "VOTO EMITIDO EXITOSAMENTE" : throw new Exception("Ocurrió un error al emitir su voto");
        }

        public string FinalizaEleccion(int id_eleccion)
        {
            DataTable finalizaEleccionSP = dVotaciones.FinalizaEleccion(id_eleccion);
            return finalizaEleccionSP != null ? "ELECCION FINALIZADA EXITOSAMENTE" : throw new Exception("Ocurrió un error al cerrar la eleccion");
        }

    }
}
