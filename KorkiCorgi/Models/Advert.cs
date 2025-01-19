namespace KorkiCorgi.Models;
using Microsoft.EntityFrameworkCore;
using KorkiCorgi.Models.TypeConfigurations;

[EntityTypeConfiguration(typeof(AdvertEntityTypeConfiguration))] 
public class Advert {
    public int Id { get; init; }
    
    public int Cost { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Descrition { get; set; } = string.Empty;

    public bool IsOnline { get; set; } = true;
    public string MeetingPlace { get; set; } = string.Empty;
    
    
    
    public int UserId { get; set; }
}