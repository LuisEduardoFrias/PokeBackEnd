using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
//

namespace Infraestructure.Repository
{
    public class PokemonDeilsRepository
    {


        #region Singletom

        private static PokemonDeilsRepository Instance;

        public static PokemonDeilsRepository GetInstance(IConfiguration configuration)
        {
            if (Instance == null)
                Instance = new PokemonDeilsRepository(configuration);

            return Instance;
        }

        #endregion


        #region Properties

        private readonly IConfiguration _Configuration;

        #endregion


        public PokemonDeilsRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }


        public async Task<HttpResponseMessage> GetDetailsPokemons(string id) =>
            await DataAccess.DataAccess
            .GetInstance(_Configuration)
            .Request(HttpMethod.Get, "https://pokeapi.co/api/v2/pokemon/" + id).Response();


        public async Task<HttpResponseMessage> GetImagePokemon(string id) =>
            await DataAccess.DataAccess
            .GetInstance(_Configuration)
            .Request(HttpMethod.Get, "https://pokeapi.co/api/v2/pokemon/" + id).Response();

    }
}
