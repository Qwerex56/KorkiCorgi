using KorkiCorgi.Models;

namespace KorkiCorgi.Services;

/*  
    TODO - getAll
    TODO - Update?
    TODO - Reservation
 */
public interface ICalendarService {
    public IEnumerable<WeekCalendar> GetUserCalendar(int userId);
    public Task<IEnumerable<WeekCalendar>> GetUserCalendarAsync (int userId);
    public WeekCalendar? GetUserWeekCalendarById(int id);
    public Task<WeekCalendar?> GetUserWeekCalendarByIdAsync(int id);
    public WeekCalendarDayData? GetUserDayCalendar(int id, DayOfWeek day);
    public Task<WeekCalendarDayData?> GetUserDayCalendarByIdAsync(int id, DayOfWeek day);
    public bool DeleteCalendarPost(int id);
    public Task<bool> DeleteCalendarPostAsync(int id);
    public bool DeleteCalendarWeek(int id);
    public Task<bool> DeleteCalendarWeekAsync(int id);
    public bool CreateCalendarPost(WeekCalendarDayData dayData);
    public Task<bool> CreateCalendarPostAsync(WeekCalendarDayData dayData);
    public bool CreateCalendarWeek(WeekCalendar weekCalendar);
    public Task<bool> CreateCalendarWeekAsync(WeekCalendar weekCalendar);

    // public bool ReserveCalendarPost(int id);
    // public Task<bool> ReserveCalendarPostAsync(int id);

}