using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
//
using Entity.Dtos;
using Entity.Models;
using Infraestructure.Repository;
//

namespace PokeApi.Controllers
{
    public class BaseController : Controller
    {
        private readonly IMapper _Mapper;
        public  readonly IConfiguration _Configuration;

        public BaseController(IMapper mapper, IConfiguration configuration)
        {
            _Mapper = mapper;
            _Configuration = configuration;
        }

        private ActionResult GetStatusCode(HttpResponseMessage Response) =>
            Response.StatusCode switch
            {
                HttpStatusCode.BadRequest => BadRequest(),
                HttpStatusCode.NotFound => NotFound()
            };


        public async Task<ActionResult<string>> DeserializeGetStringAsync(HttpResponseMessage Response)
        {
            if (Response.IsSuccessStatusCode)
            {
                PokemonDetail pokemonDetail = await JsonSerializer.DeserializeAsync<PokemonDetail>(await Response.Content.ReadAsStreamAsync());

                if (pokemonDetail.sprites.versions.generationv.blackwhite.animated != null)
                {
                    return pokemonDetail.sprites.versions.generationv.blackwhite.animated.front_default;
                }
            }

            return GetStatusCode(Response);
        }


        public async Task<ActionResult<PaginationPokemonDto>> DeserializeAsync(HttpResponseMessage Response)
        {
            if (Response.IsSuccessStatusCode)
            {
                Stream json = await Response.Content.ReadAsStreamAsync();

                PaginationPokemon pokemons = await JsonSerializer
                     .DeserializeAsync<PaginationPokemon>(json);

                var PokeDto = _Mapper.Map<PaginationPokemonDto>(pokemons);

                foreach (var result in PokeDto.results)
                {

                    int LastIndex = result.url.LastIndexOf("/");
                    LastIndex = result.url.Substring(0, LastIndex - 1).LastIndexOf("/");


                    result.urlImage = (await GetImage(result.url
                        .Substring(LastIndex)
                        .Replace("/", string.Empty)
                        )
                      ).Value;
                }


                return PokeDto;
            }

            return GetStatusCode(Response);
        }


        private async Task<ActionResult<string>> GetImage(string id) =>
          await DeserializeGetStringAsync(await PokemonDeilsRepository
              .GetInstance(_Configuration)
              .GetImagePokemon(id));


        public  async Task<ActionResult<PokemonDetailDto>> DeserializeDetailsAsync(HttpResponseMessage Response)
        {
            if (Response.IsSuccessStatusCode)
            {
                Stream json = await Response.Content.ReadAsStreamAsync();

                PokemonDetail pokedetails = await JsonSerializer
                     .DeserializeAsync<PokemonDetail>(json);

                return _Mapper.Map<PokemonDetailDto>(pokedetails);
            }

            return GetStatusCode(Response);
        }


        //private async Task<ActionResult<PokemonDetailDto>> DeserializeEntityAsync(HttpResponseMessage Response)
        //{
        //    if (Response.IsSuccessStatusCode)
        //    {
        //        try
        //        {
        //            return _Mapper.Map<PokemonDetailDto>(await JsonSerializer.DeserializeAsync<PokemonDetail>(await Response.Content.ReadAsStreamAsync()));
        //        }
        //        catch (System.Exception ex)
        //        {

        //        }
        //    }

        //    return GetStatusCode(Response);

        //}


    }
}
