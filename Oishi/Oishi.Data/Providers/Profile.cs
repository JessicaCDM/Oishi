using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Providers
{
    public class Profile : IProvider<Models.Profile>
    {
        private Contexts.DatabaseContext _db;

        public Profile(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.Profile> Get()
        {
            return _db.Profiles.ToList();
        }

        public Models.Profile? GetFirst(int id)
        {
            return _db.Profiles.FirstOrDefault(x => x.Id == id);
        }

        public Models.Profile Insert(Models.Profile item)
        {
            _db.Profiles.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Models.Profile? Update(Models.Profile item)
        {
            Models.Profile? profileToUpdate = _db.Profiles.FirstOrDefault(x => x.Id == item.Id);
            if (profileToUpdate != null)
            {
                profileToUpdate.Code = item.Code;  // Retirar?Ou alterar código?
                _db.SaveChanges();
            }

            return profileToUpdate;
        }

        public bool Delete(int id)
        {
            Models.Profile? profileToDelete = _db.Profiles.FirstOrDefault(x => x.Id == id);
            if (profileToDelete != null)
            {
                _db.Profiles.Remove(profileToDelete);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
