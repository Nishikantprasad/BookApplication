using BookApplication.Data;
using BookApplication.Models;
using BookApplication.Repository;

namespace BookApplication.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbcontext _db;
        public EventRepository(ApplicationDbcontext db)
        {
            _db = db;
        }
        public void Delete(int eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            return _db.Events.ToList();
        }

        public Event GetById(int? eventId)
        {
            Event obj = _db.Events.FirstOrDefault(e => e.Id == eventId);
            return obj;
        }

        public void Insert(Event obj)
        {
            _db.Events.Add(obj);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Event obj)
        {
            _db.Events.Update(obj);
            Save();
        }
    }
}