namespace Oishi.Data.Providers
{
    public class Region : IProvider<Models.Region>
    {
        private Contexts.DatabaseContext _db;

        public Region(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.Region> Get()
        {
            return _db.Regions.ToList();
        }

        public Models.Region? GetFirstById(int id)
        {
            return _db.Regions.FirstOrDefault(x => x.Id == id);
        }

        public Models.Region Insert(Models.Region item)
        {
            _db.Regions.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Models.Region? Update(Models.Region item)
        {
            Models.Region? regionToUpdate = _db.Regions.FirstOrDefault(x => x.Id == item.Id);
            if (regionToUpdate != null)
            {
                regionToUpdate.Name = item.Name; // admin can change names or delete things
                _db.SaveChanges();
            }

            return regionToUpdate;
        }

        public bool Delete(int id)
        {
            Models.Region? regionToDelete = _db.Regions.FirstOrDefault(x => x.Id == id);
            if (regionToDelete != null)
            {
                _db.Regions.Remove(regionToDelete);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
