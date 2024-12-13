using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KorkiCorgi.Models.TypeConfigurations;

public class WeekCalendarEntityTypeConfiguration : IEntityTypeConfiguration<WeekCalendar> {
    public void Configure(EntityTypeBuilder<WeekCalendar> builder) {
        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(e => e.Days)
            .WithOne()
            .HasForeignKey(e => e.WeekCalendarId)
            .IsRequired();
    }
}