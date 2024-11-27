namespace KorkiCorgi.Models;

public class User {
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    
    public AccountInformation AccountInformation { get; } = null!;
    public AccountStatistics AccountStatistics { get; } = null!;
    
    public EducationMaterial[] EducationMaterials { get; } = [];
    public WeekCalendar[] WeekCalendars { get; } = [];
}