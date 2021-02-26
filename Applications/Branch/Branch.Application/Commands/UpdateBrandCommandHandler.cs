using System.Threading;
using System.Threading.Tasks;
using Branch.Domain.AggregatesModel.BrandAggregate;
using MediatR;

namespace Branch.Application.Commands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly IBrandRepository _brandRepository;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<bool> Handle(UpdateBrandCommand command, CancellationToken cancellationToken)
        {
            Brand brand = await _brandRepository.FindByIdAsync(command.Id);
            Address address = new Address(command.Street, command.City, command.State, command.Country, command.ZipCode);

            brand.Update(command.Name, command.Description, command.IsDisabled, address, command.JsonData);           
            _brandRepository.Update(brand);

            return await _brandRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}