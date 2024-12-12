using KorkiCorgi.Models.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace KorkiCorgi.Models;

[EntityTypeConfiguration(typeof(AccountStatisticsEntityTypeConfiguration))]
public class AccountStatistics {
    public int Id { get; set; }
    
    public uint TotalMaterialsCount { get; set; }
    public uint MaterialRating { get; set; }
    public uint OwnerRating { get; set; }

    public int UserId;
}