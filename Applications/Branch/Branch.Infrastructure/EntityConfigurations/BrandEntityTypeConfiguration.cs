using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Branch.Domain.AggregatesModel.BrandAggregate;

namespace Branch.Infrastructure.EntityConfigurations
{
    public class BrandEntityTypeConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand", BranchContext.DEFAULT_SCHEMA);
            builder.HasKey(brand => brand.Id);
            builder.Property(brand => brand.Name).IsRequired();
            builder.Property(brand => brand.Description).IsRequired();  
            builder.Property(brand => brand.IsDisabled).IsRequired();
            builder.Property(brand => brand.IsDisabled).HasDefaultValue(false);
            builder.OwnsOne(brand => brand.Address);
        }
    }
}