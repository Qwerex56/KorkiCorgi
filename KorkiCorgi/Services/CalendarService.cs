using KorkiCorgi.Models;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Services;

public class CalendarService : ICalendarService {
    private readonly CorgiDbContext _context;

    public CalendarService(CorgiDbContext context) {
        _context = context ?? throw new ArgumentNullException();
    }

    public IEnumerable<WeekCalendar> GetUserCalendar(int userId) {
        var weeks = _context.WeekCalendars.Where((i) => i.UserId == userId);
        
        return weeks;
    }

    public async Task<IEnumerable<WeekCalendar>> GetUserCalendarAsync(int userId) {
        
        throw new NotImplementedException();
    }

    public WeekCalendar? GetUserWeekCalendarById(int id) {
        // podpatrzyłem u Ciebie pattern matching,
        // ale jak zobaczyłem one-linera od ridera to musiałem go wybrać 
        return _context.WeekCalendars.Find(id);
    }

    public async Task<WeekCalendar?> GetUserWeekCalendarByIdAsync(int id) =>
        await _context.WeekCalendars.FindAsync(id);

    public WeekCalendarDayData? GetUserDayCalendar(int id) {
        // var week = GetUserWeekCalendarById(id);
        //
        // return week?.Days.First((i) => i.DayOfWeek == day);
        return _context.WeekCalendarDayData.Find(id);
    }
    
    public async Task<WeekCalendarDayData?> GetUserDayCalendarByIdAsync(int id) {
        return await _context.WeekCalendarDayData.FindAsync(id);
    }

    //TODO - Walidacja czy użytkownik może usunąć post,
    public bool DeleteCalendarPost(int id) {
        var post = _context.WeekCalendarDayData.FirstOrDefault(day => day.Id == id);

        if (post is null) {
            return false;
        }

        _context.WeekCalendarDayData.Remove(post);
        _context.SaveChanges();

        return true;
    }

    public async Task<bool> DeleteCalendarPostAsync(int id) {
        var post = await _context.WeekCalendarDayData.FirstOrDefaultAsync(day => day.Id == id);

        if (post is null) {
            return false;
        }

        _context.WeekCalendarDayData.Remove(post);
        await _context.SaveChangesAsync();

        return true;
    }

    public bool DeleteCalendarWeek(int id) {
        var post = _context.WeekCalendars.Find(id);
        
        if (post is null) {
            return false;
        }

        _context.WeekCalendars.Remove(post);
        _context.SaveChanges();
        
        return true;
    }

    public async Task<bool> DeleteCalendarWeekAsync(int id) {
        var post = await _context.WeekCalendars.FindAsync(id);
        if (post is null) {
            return false;
        }

        _context.WeekCalendars.Remove(post);
        await _context.SaveChangesAsync();
        return true;
    }

    public bool CreateCalendarPost(WeekCalendarDayData dayData) {
        if (_context.WeekCalendarDayData.Find(dayData.Id) is null) {
            return false;
        }

        _context.WeekCalendarDayData.Add(dayData);
        _context.SaveChanges();
        return true;
    }

    public async Task<bool> CreateCalendarPostAsync(WeekCalendarDayData dayData) {
        var findAsync = await _context.WeekCalendarDayData.FindAsync(dayData.Id);
        if (findAsync is null) {
            return false;
        }

        _context.WeekCalendarDayData.Add(dayData);
        await _context.SaveChangesAsync();
        return true;
    }

    public bool CreateCalendarWeek(WeekCalendar weekCalendar) {
        if (_context.WeekCalendars.Find(weekCalendar.Id) is null) {
            return false;
        }

        _context.WeekCalendars.Add(weekCalendar);
        _context.SaveChanges();
        return true;
    }

    public async Task<bool> CreateCalendarWeekAsync(WeekCalendar weekCalendar) {
        //nie wiem, czy tak można xD 
        if (await _context.WeekCalendars.FindAsync(weekCalendar.Id) is null) {
            return false;
        }

        _context.WeekCalendars.Add(weekCalendar);
        await _context.SaveChangesAsync();
        return true;
    }
    //
    // public bool ReserveCalendarPost(int id) {
    //     throw new NotImplementedException();
    // }
    //
    // public async Task<bool> ReserveCalendarPostAsync(int id) {
    //     throw new NotImplementedException();
    // }
}