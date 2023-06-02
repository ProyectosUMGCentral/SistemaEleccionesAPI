using Elecciones.BLL;
using Elecciones.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Elecciones.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    [RoutePrefix("api/consultas")]
    public class ConsultasController : ApiController
    {
        BConsulta bConsulta = new BConsulta();

        [Route("ciudadano")]
        [HttpGet]
        public ciudadanoDTO obtenerCiudadano(string identificacion)
        {
            return bConsulta.GetCiudadano(identificacion);
        }

    }
}
