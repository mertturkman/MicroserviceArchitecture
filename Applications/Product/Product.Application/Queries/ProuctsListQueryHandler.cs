using System.Threading;
using System.Threading.Tasks;
using Product.Application.Models;
using Product.Domain.AggregatesModel.ProductAggregate;
using MediatR;

namespace Product.Application.Queries
{
    public class ProductsListQueryHandler : IRequestHandler<ProductsListQuery, ProductViewModel[]>
    {
        
        private readonly IProductRepository _productRepository;

        public ProductsListQueryHandler(IProductRepository roleRepository)
        {
           _productRepository = roleRepository;
        }

        public async Task<ProductViewModel[]> Handle(ProductsListQuery query, CancellationToken cancellationToken)
        {
            Product.Domain.AggregatesModel.ProductAggregate.Product[] productList = await _productRepository.GetAllAsync();
            return AutoMapper.Mapper.Map<ProductViewModel[]>(productList);
        }

    }
}