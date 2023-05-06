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
        private readonly IConfiguration _Configuration;
        public AccountController(IConfiguration configuration)
        {
            _OishiWebApiAddress = configuration.GetValue<string>("OishiWebApiAddress");
            _Configuration = configuration;
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

        public ActionResult ConfirmEmail()
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
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            string isValid = "false";
            if (ModelState.IsValid)
            {
                using (Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
                {
                    string? apiResponse = await webAPIProvider.Get($"UserAccount/GetFirstByEmail?email={model.Email}");
                    LoginViewModel user = JsonConvert.DeserializeObject<LoginViewModel>(apiResponse);
                    if (user != null)
                    {
                        if (user.Password == Shared.Providers.CryptographyProvider.EncodeToBase64(model.Password))
                        {
                            if (user.UserAccountStatus == Shared.Enums.UserAccountStatus.Active)
                            {
                                string authenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                                // Generate Claims from DbEntity
                                List<Claim> claims = new List<Claim>();
                                claims.Add(new Claim(ClaimTypes.Email, user.Email));
                                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));

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
                                return View(model);
                            }
                        }
                    }
                    ModelState.AddModelError(string.Empty, "Dados de login inválidos!");
                }

            }
            return View(model);
        }


        public async Task<IActionResult> LogoutAsync()
        {
            await this.HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectPermanent("~/Home/Index");
        }

        // POST: UserAccountsController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
                {
                    //string email = model.Email;
                    string? apiResponse = await webAPIProvider.Get($"UserAccount/GetFirstByEmail?email={model.Email}");

                    if (apiResponse == "")
                    {
                        apiResponse = await webAPIProvider.Post($"UserAccount/RegisterInternalAccount", model);
                        model = JsonConvert.DeserializeObject<RegisterViewModel>(apiResponse);
                        if (model != null)
                        {


                            var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = model.Id, token = model.ConfirmationToken.ToString() }, protocol: HttpContext.Request.Scheme);

                            string mensagem = "Por favor, confirme seu registro clicando no seguinte link: <a href=\"" + confirmationLink + "\">link</a>";

                            string host = _Configuration.GetValue<string>("SMTP:Host");
                            string nome = _Configuration.GetValue<string>("SMTP:Nome");
                            string userName = _Configuration.GetValue<string>("SMTP:UserName");
                            string senha = _Configuration.GetValue<string>("SMTP:Senha");
                            int porta = _Configuration.GetValue<int>("SMTP:Porta");

                            Shared.Services.ServiceEmail serviceEmail = new Shared.Services.ServiceEmail();

                            serviceEmail.EnviarEmail(model.Email, "Confimar o registo", mensagem, host, nome, userName, senha, porta);

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
            ModelState.AddModelError("", "Ocorreu algum erro, tente novamente!");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            using (Shared.Providers.WebAPIProvider webAPIProvider = new Shared.Providers.WebAPIProvider(_OishiWebApiAddress))
            {
                RegisterViewModel model = new RegisterViewModel();

                string? apiResponse = await webAPIProvider.Get($"UserAccount/GetFirst?id={userId}");
                model = JsonConvert.DeserializeObject<RegisterViewModel>(apiResponse);

                if (model != null && model.ConfirmationToken.ToString() == token)
                {
                    apiResponse = await webAPIProvider.Get($"UserAccount/ActivateUserAccount?id={userId}");
                    model = JsonConvert.DeserializeObject<RegisterViewModel>(apiResponse);
                    if (model != null)
                    {
                        ViewData["Success"] = "E-mail confirmado com sucesso!";
                        return View("Login");
                    }
                }
                ModelState.AddModelError("", "E-mail não confirmado, tente novamente!");
                return RedirectToAction("Register");
            }
        }
    }
}
