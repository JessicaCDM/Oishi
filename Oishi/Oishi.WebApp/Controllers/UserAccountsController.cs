using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oishi.WebApp.Models;

namespace Oishi.WebApp.Controllers
{
    public class UserAccountsController : Controller
    {
        // GET: UserAccountsController/Register
        public ActionResult Register()
        {
            return View();
        }

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
