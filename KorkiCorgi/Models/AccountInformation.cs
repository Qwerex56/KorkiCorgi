namespace KorkiCorgi.Models;

public class AccountInformation {
    public string Email { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public int UserId { get; set; }
}