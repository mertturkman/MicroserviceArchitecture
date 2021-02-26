using System.Threading;
using System.Threading.Tasks;
using Product.Domain.AggregatesModel.ProductAggregate;
using Product.Domain.AggregatesModel.BranchAggregate;
using MediatR;

namespace Product.Application.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IBranchRepository _branchRepository;

        public CreateProductCommandHandler(IProductRepository productRepository, IBranchRepository branchRepository)
        {
            _productRepository = productRepository;
            _branchRepository = branchRepository;
        }

        public async Task<bool> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Branch branch = await _branchRepository.FindByIdAsync(command.BranchId);
            ProductDetail productDetail = new ProductDetail(command.JsonData);
            Product.Domain.AggregatesModel.ProductAggregate.Product product = 
                new Product.Domain.AggregatesModel.ProductAggregate.Product(command.Name, command.Description, false, 
                productDetail, branch);
            _productRepository.Create(product);

            return await _productRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}