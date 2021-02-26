using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.AggregatesModel.ProductAggregate;

namespace Product.Infrastructure.EntityConfigurations
{
    public class ProductDetailEntityTypeConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("ProductDetail", ProductContext.DEFAULT_SCHEMA);
            builder.HasKey(productDetail => productDetail.Id);
            builder.Property(productDetail => productDetail.JsonData).IsRequired();  
        }
    }
}