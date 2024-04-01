using BookApplication.Models;

namespace BookApplication.Business_Layer
{
    public interface IEventFacade
    {
        public void Add(Event obj);
        public List<Event> GetAllEvents();
        public Event GetEventById(int? Id);
        public void Edit(Event obj);
        public List<Comment> GetAllComments();
        public EventCommentViewModel GetDetailsCommentViewModel(Event obj, List<Comment> comments);
        public void AddComment(Comment comment);
    }
}