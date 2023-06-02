using Elecciones.BLL;
using Elecciones.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Elecciones.Controllers
{
    [RoutePrefix("api/conteo")]
    public class ConteoController : ApiController
    {

        BConteo bConteo = new BConteo();

        [Route("votos/centrovotacion")]
        [HttpGet]
        public ResultadoConteoVotosDTO ObtenerConteoVotosGlobal()
        {
            return bConteo.GetConteoVotos(null);
        }

        [Route("votos/centrovotacion/{centro_votacion:regex(^\\d?$)}")]
        [HttpGet]
        public ResultadoConteoVotosDTO ObtenerConteoVotos(int? centro_votacion)
        {
            return bConteo.GetConteoVotos(centro_votacion);
        }

        [Route("porcentaje/centrovotacion/{centro_votacion:regex(^\\d+$)}")]
        [HttpGet]
        public ResultadoPorcentajeCentroVotacionDTO ObtenerPorcentajeCentroVotacion(int centro_votacion)
        {
            return bConteo.PorcentajeCentroVotacion(centro_votacion);
        }


    }
}
