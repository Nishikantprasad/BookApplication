using BookApplication.Models;

namespace BookApplication.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event GetById(int? eventId);
        void Insert(Event obj);
        void Update(Event obj);
        void Delete(int eventId);
        void Save();
    }
}