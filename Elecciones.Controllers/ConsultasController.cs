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
