using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KorkiCorgi.Models.TypeConfigurations;

public class AccountStatisticsEntityTypeConfiguration : IEntityTypeConfiguration<AccountStatistics> {
    public void Configure(EntityTypeBuilder<AccountStatistics> builder) {
        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}