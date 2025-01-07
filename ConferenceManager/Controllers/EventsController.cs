using ConferenceManager.Services;
using ConferenceManager.Model;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private EventsService eventService;

        public EventsController(EventsService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEventById(int id)
        {
            Event? eventById = eventService.GetEventById(id);
            if(eventById != null) return Ok(eventById);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetEvent()
        {
            var events = eventService.GetEvents();
            return Ok(events);
        }

        [HttpPost]
        public IActionResult PostEvent(Event eventToAdd)
        {
           var addedEvent = eventService.AddEvent(eventToAdd);
           return Ok(addedEvent);
        }


    }
}
