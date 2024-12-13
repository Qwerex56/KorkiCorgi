using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KorkiCorgi.Models.TypeConfigurations;

public class WeekCalendarDayDataEntityTypeConfiguration : IEntityTypeConfiguration<WeekCalendarDayData> {
    public void Configure(EntityTypeBuilder<WeekCalendarDayData> builder) {
        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}