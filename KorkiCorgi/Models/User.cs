using System.ComponentModel.DataAnnotations;
using KorkiCorgi.Models.Enums;
using KorkiCorgi.Models.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

[EntityTypeConfiguration(typeof(UserEntityTypeConfiguration))]
public class User : IUser {
    public int Id { get; init; }
    
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(32)]
    public string Password { get; set; } = string.Empty;
    public AccountType AccountType { get; set; } = AccountType.User;
    public AccountStatistics AccountStatistics { get; set; } = null!;

    public ICollection<EducationMaterial> EducationMaterials { get; init; } = [];
    public ICollection<WeekCalendar> WeekCalendars { get; init; } = [];
}