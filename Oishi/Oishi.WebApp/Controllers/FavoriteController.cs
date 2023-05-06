using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Oishi.WebApp.Controllers
{
    [Authorize]
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
				int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
				string? apiResponse = await webAPIProvider.Get($"Favorite/Toggle?userAccountId={userId}&advertisementId={id}");
                if (apiResponse != null)
                    result =  JsonConvert.DeserializeObject<bool>(apiResponse);
            }
            return result;
        }
    }
}
