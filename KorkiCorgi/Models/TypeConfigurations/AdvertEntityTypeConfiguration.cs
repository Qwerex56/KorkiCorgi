using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KorkiCorgi.Models.TypeConfigurations;

public class AdvertEntityTypeConfiguration : IEntityTypeConfiguration<Advert> {
    public void Configure(EntityTypeBuilder<Advert> builder) {
        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}