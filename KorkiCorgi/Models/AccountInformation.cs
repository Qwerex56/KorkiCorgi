using System.ComponentModel.DataAnnotations;
using KorkiCorgi.Models.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

[EntityTypeConfiguration(typeof(AccountInformationEntityTypeConfiguration))]
public class AccountInformation {
    public int Id { get; init; }

    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(16)]
    public string Login { get; set; } = string.Empty;

    [MaxLength(32)]
    public string Password { get; set; } = string.Empty;

    public int UserId { get; init; }
}