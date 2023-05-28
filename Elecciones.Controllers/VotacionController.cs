using Elecciones.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Elecciones.Controllers
{
    [RoutePrefix("api/votacion")]
    public class VotacionController : ApiController
    {

        private BVotaciones bVotaciones = new BVotaciones();

        [Route("{id_eleccion:regex(^\\d$)}")]
        [HttpPost]
        public string IniciarEleccion(int id_eleccion)
        {
            return bVotaciones.InicioElecciones(id_eleccion);
        }

    }
}
