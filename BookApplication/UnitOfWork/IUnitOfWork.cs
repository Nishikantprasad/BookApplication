using BookApplication.Repository;
using Microsoft.EntityFrameworkCore;
using BookApplication.Data;

namespace BookApplication.UnitOfWork
{
    public interface IUnitOfWork
    {
        public EventRepository EventRepository { get; }
        public CommentRepository CommentRepository { get; }
        void Save();
    }
}