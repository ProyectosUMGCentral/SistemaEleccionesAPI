using Elecciones.BEL;
using Elecciones.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Elecciones.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/votacion")]
    public class VotacionController : ApiController
    {

        private BVotaciones bVotaciones = new BVotaciones();

        [Route("iniciareleccion/{id_eleccion:regex(^\\d+$)}")]
        [HttpPost]
        public string IniciarEleccion(int id_eleccion)
        {
            return bVotaciones.InicioElecciones(id_eleccion);
        }

        [Route("")]
        [HttpPost]
        public string EmitirVoto(EEmisionVoto votoPayload)
        {
            return bVotaciones.EmitirVoto(votoPayload);
        }

        [Route("finalizareleccion/{id_eleccion:regex(^\\d+$)}")]
        [HttpPost]
        public string FinalizaEleccion(int id_eleccion)
        {
            return bVotaciones.FinalizaEleccion(id_eleccion);
        }

    }
}
