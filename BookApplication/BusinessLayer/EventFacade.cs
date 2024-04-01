using BookApplication.Data;
using BookApplication.Models;
using BookApplication.Services;
using BookApplication.UnitOfWork;
using System.Xml.Linq;

namespace BookApplication.Business_Layer
{
    public class EventFacade : IEventFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbcontext _db;
        private readonly SingletonLoggingService _singletonLoggingService;
        public EventFacade(ApplicationDbcontext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _singletonLoggingService = SingletonLoggingService.GetInstance;
        }
        public void Add(Event obj)
        {
            _unitOfWork.EventRepository.Insert(obj);
        }
        public List<Event> GetAllEvents()
        {
            return _unitOfWork.EventRepository.GetAll().ToList();
        }
        public Event GetEventById(int? Id)
        {

            return _unitOfWork.EventRepository.GetById(Id);
        }
        public void Edit(Event obj)
        {
            _unitOfWork.EventRepository.Update(obj);
        }
        public List<Comment> GetAllComments()
        {
            return _unitOfWork.CommentRepository.GetAll().ToList();
        }
        public EventCommentViewModel GetDetailsCommentViewModel(Event obj, List<Comment> comments)
        {
            return new EventCommentViewModel()
            {
                Event = obj,
                Comment = new Comment(),
                Comments = comments

            };
        }
        public void AddComment(Comment comment)
        {

            _unitOfWork.CommentRepository.Insert(comment);
        }
    }
}