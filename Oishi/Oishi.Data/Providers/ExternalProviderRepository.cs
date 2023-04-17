using Oishi.Data.Contexts;
using Oishi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Providers
{
    public class ExternalProviderRepository
    {
        private DatabaseContext _databaseContext;

        public ExternalProviderRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool Delete(int id)
        {
            ExternalProvider? externalProvider = _databaseContext.ExternalProviders.FirstOrDefault(p => p.Id == id);
            if (externalProvider != null)
            {
                _databaseContext.ExternalProviders.Remove(externalProvider);
                _databaseContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ExternalProvider> Get()
        {
            return _databaseContext.ExternalProviders.ToList();
        }

        public ExternalProvider? GetFirst(int id)
        {
            return _databaseContext.ExternalProviders.FirstOrDefault(x => x.Id == id);
        }

        public ExternalProvider Insert(ExternalProvider item)
        {
            _databaseContext.ExternalProviders.Add(item);
            _databaseContext.SaveChanges();
            return item;
        }
    }
}
