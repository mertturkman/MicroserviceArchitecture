using System.Threading;
using System.Threading.Tasks;
using Branch.Domain.AggregatesModel.BranchAggregate;
using MediatR;

namespace Branch.Application.Commands
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, bool>
    {
        private readonly IBranchRepository _branchRepository;

        public UpdateBranchCommandHandler(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<bool> Handle(UpdateBranchCommand command, CancellationToken cancellationToken)
        {
            Branch.Domain.AggregatesModel.BranchAggregate.Branch branch = await _branchRepository.FindByIdAsync(command.Id);
            branch.BranchDetail.Update(command.JsonData);
            Address address = new Address(command.Street, command.City, command.State, command.Country, command.ZipCode);

            branch.Update(command.Name, command.Description, command.IsDisabled, address);           
            _branchRepository.Update(branch);

            return await _branchRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}