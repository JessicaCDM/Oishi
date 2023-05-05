using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Oishi.WebApp.Controllers
{
    public class FavoriteController : Controller
    {
        private string _OishiWebApiAddress;
        public FavoriteController(IConfiguration configuration)
        {
            _OishiWebApiAddress = configuration.GetValue<string>("OishiWebApiAddress");
        }

        public async Task<bool?> Toggle(int id)
        {
            bool? result = null;
            using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                // TODO: Replace '3' with the real UserAccountId
                string? apiResponse = await webAPIProvider.Get($"Favorite/Toggle?userAccountId={3}&advertisementId={id}");
                if (apiResponse != null)
                    result =  JsonConvert.DeserializeObject<bool>(apiResponse);
            }
            return result;
        }
    }
}
