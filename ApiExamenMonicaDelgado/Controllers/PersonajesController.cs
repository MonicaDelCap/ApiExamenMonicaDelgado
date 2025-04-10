using ApiExamenMonicaDelgado.Models;
using ApiExamenMonicaDelgado.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenMonicaDelgado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySeries repositorySeries;

        public PersonajesController(RepositorySeries repository)
        {
            this.repositorySeries = repository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await repositorySeries.GetPersonajesAsync();
        }

        [HttpPut]
        [Route("[action]/{idpersona}/{idserie}")]
        public async Task<ActionResult> UpdatePersonajeSerie(int idpersona, int idserie)
        {
            await repositorySeries.UpdatePersonajeSerieAsync(idpersona,idserie);
            return Ok();
        }
    }
}
