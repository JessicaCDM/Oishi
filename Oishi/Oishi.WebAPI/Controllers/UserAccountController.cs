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
        private Data.Providers.Profile _profileProvider;

        public UserAccountController(Data.Contexts.DatabaseContext dbcontext) 
        {
            _userProvider = new UserAccountRepository(dbcontext);
            _userInternalLoginRepository = new UserInternalLoginRepository(dbcontext);
            _profileProvider = new Data.Providers.Profile(dbcontext);
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
        public UserAccount? GetFirstByEmail(string email)
        {
            return _userProvider.GetFirstByEmail(email);
        }

        [HttpPost]
        public UserAccount Insert(RegisterViewModel registerUser)
        {
            UserAccount userAccount = new UserAccount()
            {
                Username = registerUser.Username,
                Email = registerUser.Email,
        };
            return _userProvider.Insert(userAccount);
        }

        [HttpPost]
        public UserAccount RegisterInternalAccount(RegisterViewModel model)
        {
            UserAccount userAccount = new UserAccount()
            {
                Username = model.Username,
                Email = model.Email,
                ProfileId = _profileProvider.GetFirstByCode("User").Id,
                UserAccountStatus = Shared.Enums.UserAccountStatus.EmailToApprove,
                UserInternalLogin = new UserInternalLogin()
                {
                    ConfirmationToken = Guid.NewGuid(),
                    PasswordHash = Shared.Providers.CryptographyProvider.EncodeToBase64(model.Password)
                }
            };
            return _userProvider.Insert(userAccount);
        }

        [HttpGet]
        public UserAccount? ActivateUserAccount(int id)
        {
            UserAccount? userAccount = _userProvider.GetFirstById(id);

            if (userAccount != null)
            {
                userAccount.UserAccountStatus = Shared.Enums.UserAccountStatus.Active;
            }

            return _userProvider?.Update(userAccount);
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
