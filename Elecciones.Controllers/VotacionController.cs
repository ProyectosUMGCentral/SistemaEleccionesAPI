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

        [Route("")]
        [HttpGet]
        public string GenerateBitacora()
        {
            return bVotaciones.BLLGetResultado();
        }

    }
}
