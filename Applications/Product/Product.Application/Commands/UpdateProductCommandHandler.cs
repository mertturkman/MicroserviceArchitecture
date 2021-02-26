using System.Threading;
using System.Threading.Tasks;
using Product.Domain.AggregatesModel.ProductAggregate;
using Product.Domain.AggregatesModel.BranchAggregate;
using MediatR;

namespace Product.Application.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository, IBranchRepository branchRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            Product.Domain.AggregatesModel.ProductAggregate.Product product = await _productRepository.FindByIdAsync(command.Id);
            product.Update(command.Name, command.Description, command.IsDisabled, command.JsonData);           
            _productRepository.Update(product);

            return await _productRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}