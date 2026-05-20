using ApiAWSPersonajes.Models;
using ApiAWSPersonajes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace ApiAWSPersonajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryTelevision repo;
        public PersonajesController(RepositoryTelevision repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePersonaje(Personaje p)
        {
            await this.repo.CreatePersonajeAsync(p.Nombre, p.Imagen);
            return Ok();
        }
    }
}
