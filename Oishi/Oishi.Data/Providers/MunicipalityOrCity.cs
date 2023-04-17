using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Providers
{
    public class MunicipalityOrCity : IProvider<Models.MunicipalityOrCity>
    {
        private Contexts.DatabaseContext _db;

        public MunicipalityOrCity(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.MunicipalityOrCity> Get()
        {
            return _db.MunicipalityOrCities.ToList();
        }

        public Models.MunicipalityOrCity? GetFirst(int id)
        {
            return _db.MunicipalityOrCities.FirstOrDefault(x => x.Id == id);
        }

        public Models.MunicipalityOrCity Insert(Models.MunicipalityOrCity item)
        {
            _db.MunicipalityOrCities.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Models.MunicipalityOrCity? Update(Models.MunicipalityOrCity item)
        {
            Models.MunicipalityOrCity? municipalityOrCityToUpdate = _db.MunicipalityOrCities.FirstOrDefault(x => x.Id == item.Id);
            if (municipalityOrCityToUpdate != null)
            {
                municipalityOrCityToUpdate.Name = item.Name;
                municipalityOrCityToUpdate.RegionId = item.RegionId;
                _db.SaveChanges();
            }

            return municipalityOrCityToUpdate;
        }

        public bool Delete(int id)
        {
            Models.MunicipalityOrCity? municipalityOrCityToDelete = _db.MunicipalityOrCities.FirstOrDefault(x => x.Id == id);
            if (municipalityOrCityToDelete != null)
            {
                _db.MunicipalityOrCities.Remove(municipalityOrCityToDelete); //admin can remove cities or municipality
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
