using Oishi.Data.Contexts;
using Oishi.Data.Models;

namespace Oishi.Data.Providers
{
    public class UserExternalLoginRepository
    {
        private DatabaseContext _databaseContext;

        public UserExternalLoginRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Delete(int id)
        {
            UserExternalLogin? userExternalDelete = _databaseContext.UserExternalLogins.FirstOrDefault(e => e.Id == id);
            if (userExternalDelete != null)
            {
                _databaseContext.UserExternalLogins.Remove(userExternalDelete);
                _databaseContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<UserExternalLogin> Get()
        {
            return _databaseContext.UserExternalLogins.ToList();
        }

        public UserExternalLogin? GetFirst(int id)
        {
            return _databaseContext.UserExternalLogins.FirstOrDefault(e => e.Id == id);
        }

        public UserExternalLogin Insert(UserExternalLogin item)
        {
            _databaseContext.UserExternalLogins.Add(item);
            _databaseContext.SaveChanges();
            return item;
        }
    }
}
