using Oishi.Data.Contexts;
using Oishi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Providers
{
    public class UserInternalLoginRepository : IProvider<UserInternalLogin>
    {
        private DatabaseContext _databaseContext;

        public UserInternalLoginRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Delete(int id)
        {
            UserInternalLogin? userInternalDelete = _databaseContext.UserInternalLogins.FirstOrDefault(i => i.UserAccountId == id);
            if (userInternalDelete != null)
            {
                _databaseContext.UserInternalLogins.Remove(userInternalDelete);
                _databaseContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<UserInternalLogin> Get()
        {
            return _databaseContext.UserInternalLogins.ToList();
        }

        public UserInternalLogin? GetFirstById(int id)
        {
            return _databaseContext.UserInternalLogins.FirstOrDefault(i => i.UserAccountId == id);
        }

        public UserInternalLogin Insert(UserInternalLogin item)
        {
            _databaseContext.UserInternalLogins.Add(item);
            _databaseContext.SaveChanges();
            return item;
        }

        public UserInternalLogin? Update(UserInternalLogin item)
        {
            UserInternalLogin? userInternalLogin = _databaseContext.UserInternalLogins.FirstOrDefault(i => i.UserAccountId == item.UserAccountId);
            if (userInternalLogin != null)
            {
                userInternalLogin.PasswordHash      = item.PasswordHash;
                userInternalLogin.ConfirmationToken = item.ConfirmationToken;
                _databaseContext.SaveChanges();
            }
            return userInternalLogin;
        }
    }
}
