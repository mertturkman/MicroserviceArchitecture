using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Branch.Domain.AggregatesModel.BranchAggregate;

namespace Branch.Infrastructure.EntityConfigurations
{
    public class BranchEntityTypeConfiguration : IEntityTypeConfiguration<Branch.Domain.AggregatesModel.BranchAggregate.Branch>
    {
        public void Configure(EntityTypeBuilder<Branch.Domain.AggregatesModel.BranchAggregate.Branch> builder)
        {
            builder.ToTable("Branch", BranchContext.DEFAULT_SCHEMA);
            builder.HasKey(branch => branch.Id);
            builder.Property(branch => branch.Name).IsRequired();
            builder.Property(branch => branch.Description).IsRequired();
            builder.Property(branch => branch.IsDisabled).IsRequired();
            builder.Property(branch => branch.IsDisabled).HasDefaultValue(false);
            builder.OwnsOne(branch => branch.Address);

        }
    }
}