using BookApplication.Data;
using BookApplication.Services;
using BookApplication.UnitOfWork;

namespace BookApplication.Business_Layer
{
    public class EventFacadeFactory : IFacadeFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbcontext _db;
        private readonly SingletonLoggingService _singletonLoggingService;
        public EventFacadeFactory(ApplicationDbcontext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _singletonLoggingService = SingletonLoggingService.GetInstance;
        }
        public IEventFacade CreateEventFacade()
        {
            return new EventFacade(_db, _unitOfWork);
        }

        
    }
}