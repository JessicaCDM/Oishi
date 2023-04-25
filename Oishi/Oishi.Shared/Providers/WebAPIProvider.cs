using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Shared.Providers
{
    public class WebAPIProvider : IDisposable
    {
        private string? _webAPIAddress;

        public WebAPIProvider(string webAPIAddress)
        {
            _webAPIAddress = webAPIAddress;
        }


        public async Task<string?> Request(string endpoint)
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

        public void Dispose()
        {
            _webAPIAddress = null;
        }
    }
}
