namespace Oishi.Data.Providers
{
    public class Message 
    {
        private Contexts.DatabaseContext _db;

        public Message(Contexts.DatabaseContext db)
        {
            _db = db;
        }

        public List<Models.Message> Get()
        {
            return _db.Messages.ToList();
        }

        public Models.Message? GetFirst(int id)
        {
            return _db.Messages.FirstOrDefault(x => x.Id == id);
        }

        public Models.Message Insert(Models.Message item)
        {
            item.Date = DateTime.Now;
            _db.Messages.Add(item);
            _db.SaveChanges();
            return item;
        }

        public bool Delete(int id)
        {
            Models.Message? messageToDelete = _db.Messages.FirstOrDefault(x => x.Id == id);
            if (messageToDelete != null)
            {
                _db.Messages.Remove(messageToDelete);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
