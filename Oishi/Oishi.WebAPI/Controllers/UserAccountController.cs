using Microsoft.AspNetCore.Mvc;
using Oishi.Data.Models;
using Oishi.Data.Providers;

namespace Oishi.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private UserAccountRepository _userProvider;

        public UserAccountController(Data.Contexts.DatabaseContext dbcontext) 
        {
            _userProvider = new UserAccountRepository(dbcontext);
        }

        [HttpGet]
        public UserAccount[] Get()
        {
            return _userProvider.Get().ToArray();
        }

        [HttpGet]
        public UserAccount? GetFirst(int id)
        {
            return _userProvider.GetFirst(id);
        }

        [HttpGet]
        public UserAccount Insert(string userName, string email, string phone, DateTime birthDate)
        {
            UserAccount userAccount = new UserAccount()
            {
                Username    = userName,
                Email       = email,
                Phone       = phone,
                BirthDate   = birthDate,
            };
            return _userProvider.Insert(userAccount);
        }

        [HttpGet]
        public UserAccount? Update(int id, UserAccount updateUser)
        {
            var userAccount = _userProvider.GetFirst(id);

            if (userAccount != null)
            { 
                userAccount.Username    = updateUser.Username;
                userAccount.Email       = updateUser.Email;
                userAccount.Phone       = updateUser.Phone;
                userAccount.BirthDate   = updateUser.BirthDate;
            }
            
            return _userProvider?.Update(userAccount);
        }

        [HttpGet]
        public bool Delete(int id)
        {
            return _userProvider.Delete(id);
        }
    }
}
