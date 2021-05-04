using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
//
using Entity.Dtos;
using Infraestructure.Repository;
//

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("api/pokedetails")]
    public class PokeDetailsController : BaseController
    {

        public PokeDetailsController(IConfiguration configuration, IMapper mapper) : base(mapper, configuration)
        {

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonDetailDto>> Get(string id) =>
            await DeserializeDetailsAsync(await PokemonDeilsRepository
                .GetInstance(_Configuration).GetDetailsPokemons(id));


    }
}
