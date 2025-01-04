using System.ComponentModel.DataAnnotations;
using KorkiCorgi.Models.Enums;

namespace KorkiCorgi.DataTransferObjects;

public record UserDto {
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; init; }
    
    [Required]
    [MaxLength(32)]
    [MinLength(6)]
    public string Password { get; init; }

    public AccountType AccountType { get; init; } = AccountType.User;
}