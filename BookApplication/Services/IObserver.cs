using BookApplication.Models;


namespace BookApplication.Services
{
    public interface IObserver
    {
        void OnNotify(Comment comment);

    }
}