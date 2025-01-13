namespace KorkiCorgi.Models;

public class Advert {
    public int Id { get; init; }
    
    public int Cost { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Descrition { get; set; } = string.Empty;

    public bool IsOnline { get; set; } = true;
    public string MeetingPlace { get; set; } = string.Empty;
    
    public int UserId { get; init; }
}