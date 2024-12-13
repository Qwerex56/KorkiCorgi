using System.ComponentModel.DataAnnotations;
using KorkiCorgi.Models.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

[EntityTypeConfiguration(typeof(StudentEntityTypeConfiguration))]
public class StudentUser : IUser {
    public int Id { get; init; }

    public string Name { get; set; }

    public string Surname { get; set; }
    
    [Required]
    public AccountInformation? AccountInformation { get; init; }
    
    public ICollection<WeekCalendar> WeekCalendars { get; init; }
}