using System.ComponentModel.DataAnnotations;
using KorkiCorgi.Models.Enums;

namespace KorkiCorgi.DataTransferObjects;

public record UserDto {
    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    [MaxLength(32)]
    [MinLength(6)]
    public string Password { get; set; } = "";

    public AccountType AccountType { get; set; } = AccountType.User;
}