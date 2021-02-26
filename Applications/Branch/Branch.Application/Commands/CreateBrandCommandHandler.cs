using System.Threading;
using System.Threading.Tasks;
using Branch.Domain.AggregatesModel.BrandAggregate;
using MediatR;

namespace Branch.Application.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;
        public CreateBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<bool> Handle(CreateBrandCommand command, CancellationToken cancellationToken)
        {
            Address address = new Address(command.Street, command.City, command.State, command.Country, command.ZipCode);
            BrandDetail brandDetail = new BrandDetail(command.JsonData);

            Brand brand = new Brand(command.Name, command.Description, false, address, brandDetail);
            _brandRepository.Create(brand);

            return await _brandRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}