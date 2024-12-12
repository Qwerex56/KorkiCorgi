using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KorkiCorgi.Models.TypeConfigurations;

public class AccountInformationEntityTypeConfiguration : IEntityTypeConfiguration<AccountInformation> {
    public void Configure(EntityTypeBuilder<AccountInformation> builder) {
        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(e => e.Email)
            .IsRequired();
        
        builder
            .Property(e => e.Login)
            .IsRequired();
        
        builder
            .Property(e => e.Password)
            .IsRequired();
    }
}