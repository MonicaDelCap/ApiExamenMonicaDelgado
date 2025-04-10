using ApiExamenMonicaDelgado.Models;
using ApiExamenMonicaDelgado.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenMonicaDelgado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repositorySeries;

        public SeriesController(RepositorySeries repository)
        {
            this.repositorySeries = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Serie>>> Series()
        {
            return await this.repositorySeries.GetSeriesAsync();
        }

        [HttpGet("{idserie}")]
        public async Task<ActionResult<Serie>> SerieById(int idserie)
        {
            return await this.repositorySeries.FinSerieByIdAsync(idserie);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSerieById(int id)
        {
            return await this.repositorySeries.GetPersonajesByIdSerieAsync(id);
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Personaje>>> PersonajesSeriesById([FromQuery] List<int> id)
        {
            return await this.repositorySeries.GetPersonajesByIdSeriesAsync(id);
        }
    }




}
