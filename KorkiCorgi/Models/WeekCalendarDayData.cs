using KorkiCorgi.Models.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

//Bez rezerwowania?, Czy gdzieś przeniosłeś?
[EntityTypeConfiguration(typeof(WeekCalendarDayDataEntityTypeConfiguration))]
public class WeekCalendarDayData {
    public int Id { get; init; }
    
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public bool Completed { get; set; }
    
    public int WeekCalendarId { get; init; }
}