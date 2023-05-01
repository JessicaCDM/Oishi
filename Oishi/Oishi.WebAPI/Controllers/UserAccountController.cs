using Microsoft.AspNetCore.Mvc;
using Oishi.Data.Models;
using Oishi.Data.Providers;
using Oishi.Shared.ViewModels.Account;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private UserAccountRepository _userProvider;
        private UserInternalLoginRepository _userInternalLoginRepository;

        public UserAccountController(Data.Contexts.DatabaseContext dbcontext) 
        {
            _userProvider = new UserAccountRepository(dbcontext);
            _userInternalLoginRepository = new UserInternalLoginRepository(dbcontext);
        }

        [HttpGet]
        public UserAccount[] Get()
        {
            return _userProvider.Get().ToArray();
        }

        [HttpGet]
        public UserAccount? GetFirst(int id)
        {
            return _userProvider.GetFirstById(id);
        }

        [HttpGet]
        public UserAccount Insert(string userName, string email, string phone, DateTime birthDate, int profileId)
        {
            UserAccount userAccount = new UserAccount()
            {
                Username    = userName,
                Email       = email,
                Phone       = phone,
                BirthDate   = birthDate,
                ProfileId   = profileId,
            };
            return _userProvider.Insert(userAccount);
        }

        [HttpPost]
        public UserAccount? Update(int id, AccountEditViewModel updateUser)
        {
            UserAccount? userAccount = _userProvider.GetFirstById(id);

            if (userAccount != null)
            { 
                userAccount.Username    = updateUser.Username;
                userAccount.Email       = updateUser.Email;
                userAccount.Phone       = updateUser.Phone;
                //userAccount.BirthDate   = updateUser.BirthDate;
            }
            
            return _userProvider?.Update(userAccount);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _userProvider.Delete(id);
        }

        [HttpPost]
        public UserAccount? ProfileUpdate(int id, AccountEditViewModel updateUser)
        {
            UserAccount? userAccount = _userProvider.GetFirstById(id);

            if (userAccount != null)
            {
                userAccount.Username = updateUser.Username;
                userAccount.Email = updateUser.Email;
                userAccount.Phone = updateUser.Phone;
            }
            if (!string.IsNullOrEmpty(updateUser.Password))
            {
                UserInternalLogin? userInternalLogin = _userInternalLoginRepository.GetFirstById(id);
                if (userInternalLogin != null)
                {
                    userInternalLogin.PasswordHash = Oishi.Shared.Providers.CryptographyProvider.EncodeToBase64(updateUser.Password);
                }
            }

            return _userProvider?.Update(userAccount);
        }
    }
}
