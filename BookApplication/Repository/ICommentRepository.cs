using BookApplication.Models;

namespace BookApplication.Repository
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAll();
        Comment GetById(int? commentId);
        void Insert(Comment obj);
        void Update(Comment obj);
        void Delete(int commentId);
        void Save();
    }
}