using Oishi.Data.Contexts;
using Oishi.Data.Models;
using Oishi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Oishi.Data.Providers
{
    public class UserAccountRepository : IProvider<UserAccount>
    {
        private DatabaseContext _databaseContext;

        public UserAccountRepository(DatabaseContext dbcontext) 
        {
            _databaseContext = dbcontext;
        }

        public bool Delete(int id)
        {
            UserAccount? userDelete = _databaseContext.UserAccounts.FirstOrDefault(u => u.Id == id);
            if (userDelete != null)
            {
                _databaseContext.UserAccounts.Remove(userDelete);
                _databaseContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<UserAccount> Get()
        {
            return _databaseContext.UserAccounts.ToList();
        }

        public UserAccount? GetFirst(int id)
        {
            return _databaseContext.UserAccounts.FirstOrDefault(u => u.Id == id);
        }

        public UserAccount Insert(UserAccount item)
        {
            item.LastLogin              = DateTime.Now;
            item.DateCreated            = DateTime.Now;
            UserExternalLogin? idUserExternalLogin = _databaseContext.UserExternalLogins.FirstOrDefault(x => x.UserAccountId == item.Id);
            if (idUserExternalLogin != null)
            {
                item.UserAccountStatus = UserAccountStatus.Active;
            }
            else
            {
                item.UserAccountStatus = UserAccountStatus.EmailToApprove;
            }
            _databaseContext.UserAccounts.Add(item);
            _databaseContext.SaveChanges();
            return item;
        }

        public UserAccount? Update(UserAccount item)
        {
            UserAccount? userUpdate = _databaseContext.UserAccounts.FirstOrDefault(u =>u.Id == item.Id);
            if (userUpdate != null)
            {
                userUpdate.Username     = item.Username;
                userUpdate.Email        = item.Email;
                userUpdate.Phone        = item.Phone;
                userUpdate.BirthDate    = item.BirthDate;
                userUpdate.LastLogin    = DateTime.Now;
                _databaseContext.SaveChanges();
            }
            return userUpdate;
        }
    }
}
