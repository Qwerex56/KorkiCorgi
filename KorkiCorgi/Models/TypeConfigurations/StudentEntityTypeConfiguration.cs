using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KorkiCorgi.Models.TypeConfigurations;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<StudentUser> {
    public void Configure(EntityTypeBuilder<StudentUser> builder) {
        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        
        builder
            .Property(e => e.Name)
            .IsRequired();
        
        builder
            .Property(e => e.Surname)
            .IsRequired();

        builder
            .HasOne(e => e.AccountInformation)
            .WithOne()
            .HasForeignKey<AccountInformation>(e => e.UserId)
            .IsRequired();
        
        builder
            .HasMany(e => e.WeekCalendars)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
    }
}