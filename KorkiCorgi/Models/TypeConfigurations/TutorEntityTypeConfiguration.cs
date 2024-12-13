using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KorkiCorgi.Models.TypeConfigurations;

public class TutorEntityTypeConfiguration : IEntityTypeConfiguration<TutorUser> {
    public void Configure(EntityTypeBuilder<TutorUser> builder) {
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
        
        // Specific for tutor
        builder
            .HasOne(e => e.AccountStatistics)
            .WithOne()
            .HasForeignKey<AccountStatistics>(e => e.UserId)
            .IsRequired();
        
        builder
            .HasMany(e => e.EducationMaterials)
            .WithOne()
            .HasForeignKey(e => e.UserId)
            .IsRequired();
    }
}