using BookApplication.Data;
using BookApplication.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookApplication.UnitOfWork
{
    public class MyUnitOfWork : IUnitOfWork
    {
        private CommentRepository _commentRepository;
        private EventRepository _eventRepository;
        private ApplicationDbcontext _applicationDbContext;
        public MyUnitOfWork(ApplicationDbcontext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public EventRepository EventRepository
        {
            get
            {
                if (_eventRepository == null)
                {
                    _eventRepository = new EventRepository(_applicationDbContext);
                }
                return _eventRepository;
            }
        }
        public CommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_applicationDbContext);
                }
                return _commentRepository;
            }
        }
        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

    }
}