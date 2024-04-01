using BookApplication.Business_Layer;
using BookApplication.Data;
using BookApplication.Models;
using BookApplication.Repository;
using BookApplication.Services;
using BookApplication.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace BookApplication.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventFacade _eventFacade;
        private readonly IFacadeFactory _facadeFactory;
        private readonly List<IObserver> observers = new List<IObserver>();
        public EventController(IFacadeFactory facadeFactory)
        {
           _facadeFactory = facadeFactory;
            _eventFacade = _facadeFactory.CreateEventFacade();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEvent()
        {

            return View();  
        }
        [HttpPost]  
        public IActionResult CreateEvent(Event obj)
        {
            if(ModelState.IsValid)
            {
          
                _eventFacade.Edit(obj);
                return RedirectToAction("Index","Home") ;
            }
            return View(obj);
        }
        public IActionResult MyEvents()
        {
            List<Event> eventsFromDb = _eventFacade.GetAllEvents(); 
            return View(eventsFromDb);
        }
        public IActionResult EventDetails(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Event obj = _eventFacade.GetEventById(Id);
            if (obj == null)
            {
                return NotFound();
            }
            List<Comment> comments = _eventFacade.GetAllComments();
            EventCommentViewModel eventCommentViewModel = _eventFacade.GetDetailsCommentViewModel(obj, comments);
            return View(eventCommentViewModel);
        }
        public IActionResult MyInvitations()
        {
            var list = _eventFacade.GetAllEvents();
            return View(list);
        }
        public IActionResult Edit(int? id)
        {
            if(id ==null || id==0)
            {
                return NotFound();
            }
            var eventFromDb = _eventFacade.GetEventById(id);
            if(eventFromDb == null)
            {
                return NotFound();
            }
            return View(eventFromDb);

        }
        [HttpPost]

        public IActionResult Edit(Event obj)
        {
            if (ModelState.IsValid)
            {
                _eventFacade.Edit(obj);
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("ListAllEvents", "Event");
                }
                return RedirectToAction("MyEvents", "Event");
            }
            return View(obj);
        }

        public IActionResult ListAllEvents()
        {
            var eventList = _eventFacade.GetAllEvents();
            return View(eventList); 
        }

        [HttpPost]
        public IActionResult AddComment(EventCommentViewModel viewModel)
        {
            Comment comment = new Comment()
            {
                EventId = viewModel.Event.Id,
                CommentText = viewModel.Comment.CommentText,
                Author = User.Identity.Name,
                CreatedDate = DateTime.Now,
            };

            _eventFacade.AddComment(comment);
            var eventObj = _eventFacade.GetEventById(viewModel.Event.Id);
            observers.Add(new Observer(eventObj.CreatedBy));
            observers[0].OnNotify(comment);

            return RedirectToAction("EventDetails", "Event", new { Id = viewModel.Event.Id });
        }
    }
}
