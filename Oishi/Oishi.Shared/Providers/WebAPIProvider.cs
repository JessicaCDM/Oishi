using Newtonsoft.Json;
using System.Text;

namespace Oishi.Shared.Providers
{
    public class WebAPIProvider : IDisposable
    {
        private string? _webAPIAddress;

        public WebAPIProvider(string webAPIAddress)
        {
            _webAPIAddress = webAPIAddress;
        }

        public async Task<string?> Get(string endpoint)
        {
            string? result = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_webAPIAddress}{endpoint}"))
                {
                    using (var content = response.Content)
                    {
                        result = await content.ReadAsStringAsync();
                    }
                }
            }

            return result;
        }

        public async Task<string?> Post(string endpoint, object model)
        {
            string? result = null;
            using (var httpClient = new HttpClient())
            {
                StringContent modelContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{_webAPIAddress}{endpoint}", modelContent))
                {
                    using (var content = response.Content)
                    {
                        result = await content.ReadAsStringAsync();
                    }
                }
            }

            return result;
        }

        public void Dispose()
        {
            _webAPIAddress = null;
        }
    }
}
