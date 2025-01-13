namespace KorkiCorgi.Models;

public interface IUser {
    public int Id { get; init; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    
    
    public ICollection<WeekCalendar> WeekCalendars { get; init; }
}