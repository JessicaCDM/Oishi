namespace Oishi.Data.Providers
{
    public class AdvertisementHighlight 
    {
        private Contexts.DatabaseContext _db;

        public AdvertisementHighlight(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.AdvertisementHighlight> Get()
        {
            return _db.AdvertisementHighlights.ToList();
        }

        public Models.AdvertisementHighlight? GetFirst(int advertisementId, int hightLightTypeId)
        {
            return _db.AdvertisementHighlights.FirstOrDefault(x => x.AdvertisementId == advertisementId && x.HighLightTypeId == hightLightTypeId);
        }

        public Models.AdvertisementHighlight Insert(Models.AdvertisementHighlight item)
        {
            _db.AdvertisementHighlights.Add(item);
            _db.SaveChanges();
            return item;
        }

        public bool Delete(int advertisementId, int hightLightTypeId)
        {
            Models.AdvertisementHighlight? advertisementHighlightToDelete = _db.AdvertisementHighlights.FirstOrDefault(x => x.AdvertisementId == advertisementId && x.HighLightTypeId == hightLightTypeId);
            if (advertisementHighlightToDelete != null)
            {
                _db.AdvertisementHighlights.Remove(advertisementHighlightToDelete);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
