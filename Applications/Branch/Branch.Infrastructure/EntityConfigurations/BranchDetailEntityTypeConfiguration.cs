using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Branch.Domain.AggregatesModel.BranchAggregate;

namespace Branch.Infrastructure.EntityConfigurations
{
    public class BranchDetailEntityTypeConfiguration : IEntityTypeConfiguration<BranchDetail>
    {
        public void Configure(EntityTypeBuilder<BranchDetail> builder)
        {
            builder.ToTable("BranchDetail", BranchContext.DEFAULT_SCHEMA);
            builder.HasKey(branchDetail => branchDetail.Id);
            builder.Property(branchDetail => branchDetail.JsonData).IsRequired();  
        }
    }
}