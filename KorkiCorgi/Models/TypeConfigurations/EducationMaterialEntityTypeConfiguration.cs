using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KorkiCorgi.Models.TypeConfigurations;

public class EducationMaterialEntityTypeConfiguration : IEntityTypeConfiguration<EducationMaterial> {
    public void Configure(EntityTypeBuilder<EducationMaterial> builder) {
        builder
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}