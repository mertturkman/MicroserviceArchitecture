using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Product.Infrastructure.EntityConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product.Domain.AggregatesModel.ProductAggregate.Product>
    {
        public void Configure(EntityTypeBuilder<Product.Domain.AggregatesModel.ProductAggregate.Product> builder)
        {
            builder.ToTable("Branch", ProductContext.DEFAULT_SCHEMA);
            builder.HasKey(product => product.Id);
            builder.Property(product => product.Name).IsRequired();  
            builder.Property(product => product.IsDisabled).IsRequired();
            builder.Property(product => product.IsDisabled).HasDefaultValue(false);
        }
    }
}