using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
//

namespace Infraestructure.Repository
{
    public class PokemonRepository
    {


        #region Singletom

        private static PokemonRepository Instance;

        public static PokemonRepository GetInstance(IConfiguration configuration)
        {
            if (Instance == null)
                Instance = new PokemonRepository(configuration);

            return Instance;
        }

        #endregion


        #region Properties

        private readonly IConfiguration _Configuration;

        #endregion


        public PokemonRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }


        public async Task<HttpResponseMessage> GetPokemos(int starting) =>
            await DataAccess.DataAccess.GetInstance(_Configuration)
                .Request(HttpMethod.Get, $"pokemon/?offset={starting}&limit=20")
                .Response();


    }
}
