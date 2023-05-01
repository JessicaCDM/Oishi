using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oishi.Shared.ViewModels.Account;
using System.Security.Claims;

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

        public ActionResult Login()
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
                    string? apiResponse = await webAPIProvider.Post($"UserAccount/ProfileUpdate?id={userAccountId}", model);
                    if (apiResponse != null)
                        model = JsonConvert.DeserializeObject<AccountEditViewModel>(apiResponse);
                }
            }
            return View();
        }

        [HttpPost]
        // TODO: Trocar AccountEditViewModel por um novo (exemplo: LoginViewModel)
        public async Task<IActionResult> LoginAsync(AccountEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Verificar dados de login
                if (true)
                {
                    // TODO: Verificar estado da conta activado
                    if (true)
                    {
                        string authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                        // Generate Claims from DbEntity
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Email, model.Email));

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                                claims, authenticationScheme);

                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(
                                claimsIdentity);

                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            // Refreshing the authentication session should be allowed.
                            //ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8),
                            // The time at which the authentication ticket expires. A 
                            // value set here overrides the ExpireTimeSpan option of 
                            // CookieAuthenticationOptions set with AddCookie.
                            IsPersistent = true,
                            // Whether the authentication session is persisted across 
                            // multiple requests. Required when setting the 
                            // ExpireTimeSpan option of CookieAuthenticationOptions 
                            // set with AddCookie. Also required when setting 
                            // ExpiresUtc.
                            IssuedUtc = DateTimeOffset.UtcNow,
                            // The time at which the authentication ticket was issued.
                            //RedirectUri = "~/Account/Login"
                            // The full path or absolute URI to be used as an http 
                            // redirect response value.
                        };

                        await this.HttpContext.SignInAsync(
                            authenticationScheme,
                            claimsPrincipal,
                            authProperties);

                        return LocalRedirect("~/Home/Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Conta não activada");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Dados de login inválidos!");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await this.HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectPermanent("~/Account/Login");
        }

        // POST: UserAccountsController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (Oishi.Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
                {
                    string email = model.Email;
                    string? apiResponse = await webAPIProvider.Get($"UserAccount/GetFirstByEmail?email={email}");

                    if (apiResponse == "")
                    {
                        apiResponse = await webAPIProvider.Post($"UserAccount/RegisterInternalAccount", model);
                        if (apiResponse != null)
                        {
                            model = JsonConvert.DeserializeObject<RegisterViewModel>(apiResponse);

                            ViewData["Success"] = "Registo realizado com sucesso! Verifique o seu e-mail";
                            return View("~/Views/Account/Login.cshtml");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Utilizador já registado!");
                        return View();
                    }
                }
            }
            return View();
        }
    }
}
