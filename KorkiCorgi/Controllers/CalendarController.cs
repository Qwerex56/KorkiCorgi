using KorkiCorgi.Services;
using KorkiCorgi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KorkiCorgi.Controllers;

//TODO - https://learning.oreilly.com/library/view/architecting-asp-net-core/9781805123385/Text/Chapter_04.xhtml

[Route("api/v1/[controller]")]
[ApiController]
public class CalendarController : Controller {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService) {
                _calendarService = 
                        calendarService ?? throw new ArgumentNullException(nameof(calendarService));
        }
        [HttpPost(nameof(AddPost))]
        public IActionResult AddPost(WeekCalendarDayData dayData) {
                if (!ModelState.IsValid) {
                        return BadRequest(dayData);
                }
                var result = _calendarService.CreateCalendarPost(dayData);
                
                if (!result) {
                        return BadRequest();
                }
                
                return Ok(result);

        }
        
        //TODO - Remove Post from calendar
        
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<WeekCalendar>> GetCalendar(int userId) {
                // chyba trzeba będzie to zamienić na jakąś uniwersalną walidację
                if (!ModelState.IsValid) return BadRequest("incorrect api call.");
                
                return Ok(_calendarService.GetUserCalendar(userId));

        }
        
        //zmienić do formatu calendar/userId/calendarId? albo zmienić na calendar/GetWeekCalendar/calendarId
        [HttpGet(nameof(GetWeekCalendar) + "/{calendarId}", Name = nameof(GetWeekCalendar))]
        public ActionResult<WeekCalendar?> GetWeekCalendar (int calendarId) {
                if (!ModelState.IsValid) return BadRequest("Incorrect api call.");
                if (calendarId < 0) {
                        return NotFound(calendarId);
                }
                var result = _calendarService.GetUserWeekCalendarById(calendarId);
                if (result is not null) {
                        return Ok(result);
                }
                return NotFound(result);
        }
        
        //TODO - DeleteWeekCalendar
        //TODO - UpdatePost
}

