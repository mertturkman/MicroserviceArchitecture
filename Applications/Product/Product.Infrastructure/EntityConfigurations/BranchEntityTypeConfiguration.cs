using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.AggregatesModel.BranchAggregate;

namespace Product.Infrastructure.EntityConfigurations
{
    public class BranchEntityTypeConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branch", ProductContext.DEFAULT_SCHEMA);
            builder.HasKey(branch => branch.Id);
            builder.Property(branch => branch.BranchId).IsRequired();  
            builder.Property(branch => branch.Name).IsRequired();
            builder.Property(branch => branch.IsDisabled).IsRequired();
            builder.Property(branch => branch.IsDisabled).HasDefaultValue(false);
        }
    }
}