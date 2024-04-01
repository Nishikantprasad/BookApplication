using BookApplication.Data;
using BookApplication.Models;

namespace BookApplication.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbcontext _db;
        public CommentRepository(ApplicationDbcontext db)
        {
            _db = db;
        }
        public void Delete(int commentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _db.Comments.ToList();
        }

        public Comment GetById(int? commentId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Comment obj)
        {
            _db.Comments.Add(obj);
            Save();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}