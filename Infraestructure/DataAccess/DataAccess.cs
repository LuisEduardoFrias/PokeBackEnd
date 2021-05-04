using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infraestructure.DataAccess
{
    public class DataAccess
    {

        #region Singletom

        private static DataAccess Instance;

        public static DataAccess GetInstance(IConfiguration configuration)
        {
            if (Instance == null)
                Instance = new DataAccess(configuration);

            return Instance;
        }

        #endregion

        #region Properties

        readonly HttpClient _Client;

        HttpRequestMessage _Request;

        #endregion

        public DataAccess(IConfiguration configuration)
        {
            _Client = new HttpClient();
            _Client.BaseAddress = new Uri(configuration["BaseAddress"]);
        }

        public DataAccess Request(HttpMethod method,string uri)
        {
            _Request = new HttpRequestMessage(method, uri);

            return this;
        }

        public async Task<HttpResponseMessage> Response() =>
            await _Client.SendAsync(_Request, HttpCompletionOption.ResponseHeadersRead);

    }
}
