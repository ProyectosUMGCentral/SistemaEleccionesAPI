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
        [Route("usuario")]
        [HttpGet]
        public usuarioDTO obtenerUsuario(string email, string passWord)
        {
            return bConsulta.GetUsuario(email, passWord);
        }
        [Route("candidatos")]
        [HttpPost]
        public List<CandidatosDTO> obtenerCandidatos(consultaCandidatosDTO candidatos)
        {
            return bConsulta.GetCandidatos(candidatos);
        }
    }
}
