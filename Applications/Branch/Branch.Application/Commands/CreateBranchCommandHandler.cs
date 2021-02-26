using System.Threading;
using System.Threading.Tasks;
using Branch.Domain.AggregatesModel.BranchAggregate;
using MediatR;

namespace Branch.Application.Commands
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, bool>
    {
        private readonly IBranchRepository _branchRepository;
        public CreateBranchCommandHandler(IBranchRepository brandRepository)
        {
            _branchRepository = brandRepository;
        }

        public async Task<bool> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
        {
            Address address = new Address(command.Street, command.City, command.State, command.Country, command.ZipCode);
            BranchDetail branchDetail = new BranchDetail(command.JsonData);

            Branch.Domain.AggregatesModel.BranchAggregate.Branch brand = 
                new Branch.Domain.AggregatesModel.BranchAggregate.Branch(command.Name, command.Description, false, branchDetail, 
                address);
            _branchRepository.Create(brand);

            return await _branchRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}