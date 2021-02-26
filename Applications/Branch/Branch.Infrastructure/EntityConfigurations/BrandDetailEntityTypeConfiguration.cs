using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Branch.Domain.AggregatesModel.BrandAggregate;

namespace Branch.Infrastructure.EntityConfigurations
{
    public class BrandDetailEntityTypeConfiguration : IEntityTypeConfiguration<BrandDetail>
    {
        public void Configure(EntityTypeBuilder<BrandDetail> builder)
        {
            builder.ToTable("BrandDetail", BranchContext.DEFAULT_SCHEMA);
            builder.HasKey(brandDetail => brandDetail.Id);
            builder.Property(brandDetail => brandDetail.JsonData).IsRequired();  
        }
    }
}