using KorkiCorgi.Models.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

[EntityTypeConfiguration(typeof(TutorEntityTypeConfiguration))]
public class TutorUser : IUser {
    public int Id { get; init; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public AccountInformation? AccountInformation { get; init; }
    public AccountStatistics? AccountStatistics { get; init; }
    
    public ICollection<EducationMaterial> EducationMaterials { get; init; }
    public ICollection<WeekCalendar> WeekCalendars { get; init; }
}