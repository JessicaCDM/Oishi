using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Oishi.Shared.ViewModels.Account;

namespace Oishi.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private string _OishiWebApiAddress;
        public AccountController(IConfiguration configuration)
        {
            _OishiWebApiAddress = configuration.GetValue<string>("OishiWebApiAddress");
        }

        // GET: UserAccountsController/Register
        public ActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Edit()
        {
            AccountEditViewModel? model = null;
            using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                // TODO: Em vez de '3', usar o id do utilizador que está com login feito, quando o login estiver a funcionar
                int userAccountId = 3;
                string? apiResponse = await webAPIProvider.Get($"UserAccount/GetFirst?id={userAccountId}");
                if (apiResponse != null)
                    model = JsonConvert.DeserializeObject<AccountEditViewModel>(apiResponse);
            }
            if (model != null)
                return View(model);

            throw new Exception();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AccountEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
                {
                    // TODO: Em vez de '3', usar o id do utilizador que está com login feito, quando o login estiver a funcionar
                    int userAccountId = 3;
                    string? apiResponse = await webAPIProvider.Post($"UserAccount/Update?id={userAccountId}", model);
                    if (apiResponse != null)
                        model = JsonConvert.DeserializeObject<AccountEditViewModel>(apiResponse);
                }
            }
            return View();
        }

        // if (ModelState.IsValid)
        //    {
        //        using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
        //        {
        //            // TODO: Em vez de '3', usar o id do utilizador que está com login feito, quando o login estiver a funcionar
        //            int userAccountId = 3;
        //            string? apiResponse = await webAPIProvider.Post($"UserAccount/Update?id={userAccountId}", model);
        //            if (apiResponse != null)
        //                model = JsonConvert.DeserializeObject<AccountEditViewModel>(apiResponse);
        //        }
        //    }
        //    return View();
        //}

        // POST: UserAccountsController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
