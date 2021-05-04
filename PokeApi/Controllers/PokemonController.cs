using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//
using Entity.Dtos;
using Infraestructure.Repository;
using System.Threading.Tasks;
//

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("api/pokemon")]
    public class PokemonController : BaseController
    {


        public PokemonController(IMapper mapper, IConfiguration configuration) : base(mapper, configuration)
        {

        }


        [HttpGet("{starting}")]
        public async Task<ActionResult<PaginationPokemonDto>> GetGet(int? starting) =>
           await DeserializeAsync(await PokemonRepository
               .GetInstance(_Configuration)
               .GetPokemos(starting.Value));


        [HttpGet]
        public async Task<ActionResult<PaginationPokemonDto>> Get() =>
            await DeserializeAsync(await PokemonRepository
                       .GetInstance(_Configuration)
                       .GetPokemos(0));


    }
}

