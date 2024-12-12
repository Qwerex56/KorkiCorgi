using KorkiCorgi.Models.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

[EntityTypeConfiguration(typeof(WeekCalendarEntityTypeConfiguration))]
public class WeekCalendar {
    public int Id { get; init; }
    
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    
    public ICollection<WeekCalendarDayData>? Days { get; init; }
    
    public int UserId { get; init; }
}