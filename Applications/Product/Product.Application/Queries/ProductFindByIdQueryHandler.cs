using System.Threading;
using System.Threading.Tasks;
using Product.Application.Models;
using Product.Domain.AggregatesModel.ProductAggregate;
using MediatR;

namespace Product.Application.Queries
{
    public class ProductFindByIdQueryHandler : IRequestHandler<ProductFindByIdQuery, ProductViewModel>
    {
        private readonly IProductRepository _productRepository;
        public ProductFindByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel> Handle(ProductFindByIdQuery query, CancellationToken cancellationToken)
        {
            Product.Domain.AggregatesModel.ProductAggregate.Product product = await _productRepository.FindByIdAsync(query.Id);
            return AutoMapper.Mapper.Map<ProductViewModel>(product);
        }
    }
}