using BookApplication.Business_Layer;

namespace BookApplication.Business_Layer
{
    public interface IFacadeFactory
    {
        public IEventFacade CreateEventFacade();

    }
}