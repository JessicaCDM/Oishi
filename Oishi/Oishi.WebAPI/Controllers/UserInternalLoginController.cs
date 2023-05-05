using Microsoft.AspNetCore.Mvc;
using Oishi.Data.Models;
using Oishi.Data.Providers;
using Oishi.Shared.ViewModels;
using Oishi.Shared.ViewModels.Account;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserInternalLoginController : ControllerBase
    {
        private UserInternalLoginRepository _userInternalProvider;

        public UserInternalLoginController(Data.Contexts.DatabaseContext dbContext)
        {
            _userInternalProvider = new UserInternalLoginRepository(dbContext);
        }

        [HttpGet]
        public UserInternalLogin[] Get()
        {
            return _userInternalProvider.Get().ToArray();
        }

        [HttpGet]
        public UserInternalLogin? GetFirst(int id)
        {
            return _userInternalProvider.GetFirstById(id);
        }

        [HttpPost]
        public UserInternalLogin Insert(RegisterViewModel registerUser)
        {
            UserInternalLogin userInternalLogin = new UserInternalLogin()
            {
                UserAccountId       = registerUser.Id,
                PasswordHash        = Shared.Providers.CryptographyProvider.EncodeToBase64(registerUser.Password),
                ConfirmationToken   = Guid.NewGuid().ToString()
            };
            return _userInternalProvider.Insert(userInternalLogin);
        }

        [HttpGet]
        public UserInternalLogin? Update(int id, UserInternalLogin userInternalLogin)
        {
            var userInternal = _userInternalProvider.GetFirstById(id);

            if (userInternal != null)
            {
                userInternal.PasswordHash       = userInternalLogin.PasswordHash;
                userInternal.ConfirmationToken  = userInternalLogin.ConfirmationToken;
                userInternal.RecoveryToken      = userInternalLogin.RecoveryToken;
            }
            return _userInternalProvider?.Update(userInternalLogin);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _userInternalProvider.Delete(id);
        }
    }
}
