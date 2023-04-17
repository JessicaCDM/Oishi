using Microsoft.AspNetCore.Mvc;
using Oishi.Data.Models;
using Oishi.Data.Providers;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserExternalLoginController : ControllerBase
    {
        private UserExternalLoginRepository _userExternalProvider;

        public UserExternalLoginController(Data.Contexts.DatabaseContext dbContext)
        {
            _userExternalProvider = new UserExternalLoginRepository(dbContext);
        }

        [HttpGet]
        public UserExternalLogin[] Get()
        {
            return _userExternalProvider.Get().ToArray();
        }

        [HttpGet]
        public UserExternalLogin? GetFirst(int id) 
        {
            return _userExternalProvider.GetFirst(id);
        }

        [HttpGet]
        public UserExternalLogin Insert(int id, int idAccount, int idProvider)
        {
            UserExternalLogin userExternalLogin = new UserExternalLogin()
            { 
                Id = id,
                UserAccountId = idAccount,
                ExternalProviderId = idProvider
            };
            return _userExternalProvider.Insert(userExternalLogin);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _userExternalProvider.Delete(id);
        }
    }
}
