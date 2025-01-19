using KorkiCorgi.Models;

namespace KorkiCorgi.DataTransferObjects;

public class ProfilPanelDto {
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public AccountStatistics AccountStatistics { get; set; } = null!;
    public string Description { get; set; }
    public int Cost { get; set; }
    public bool IsOnline { get; set; } = true;
    public string MeetingPlace { get; set; } = string.Empty;
}