using ApiExamenMonicaDelgado.Data;
using ApiExamenMonicaDelgado.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenMonicaDelgado.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext con)
        {
            this.context = con;
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<Personaje> FinPersonajeByIdAsync(int idpersonaje)
        {
            return await this.context.Personajes.FirstOrDefaultAsync(x => x.IdPersonaje == idpersonaje);
        }

        public async Task UpdatePersonajeSerieAsync(int idpersonaje, int idserie)
        {
            Personaje personaje = await FinPersonajeByIdAsync(idpersonaje);
            personaje.IdSerie = idserie;
            await this.context.SaveChangesAsync();
        }


        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        public async Task<Serie> FinSerieByIdAsync(int idserie)
        {
            return await this.context.Series.FirstOrDefaultAsync(x => x.IdSerie == idserie);
        }

        public async Task<List<Personaje>> GetPersonajesByIdSerieAsync(int idserie)
        {
            var consulta = from datos in this.context.Personajes where datos.IdSerie == idserie select datos;
            return await consulta.ToListAsync();
        }

        public async Task<List<Personaje>> GetPersonajesByIdSeriesAsync(List<int> idseries)
        {
            List<Personaje> personajes = new List<Personaje>();
            foreach(int id in idseries)
            {
                List<Personaje> ps = await GetPersonajesByIdSerieAsync(id);
                foreach(Personaje p in ps)
                {
                    personajes.Add(p);
                }
            }

            return personajes;
        }
    }
}
