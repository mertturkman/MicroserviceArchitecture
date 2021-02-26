using System.Threading;
using System.Threading.Tasks;
using Branch.Application.Models;
using Branch.Domain.AggregatesModel.BranchAggregate;
using MediatR;

namespace Branch.Application.Queries
{
    public class BranchFindByIdQueryHandler : IRequestHandler<BranchFindByIdQuery, BranchViewModel>
    {
        private readonly IBranchRepository _branchRepository;
        public BranchFindByIdQueryHandler(IBranchRepository productRepository)
        {
            _branchRepository = productRepository;
        }

        public async Task<BranchViewModel> Handle(BranchFindByIdQuery query, CancellationToken cancellationToken)
        {
            Branch.Domain.AggregatesModel.BranchAggregate.Branch branch = await _branchRepository.FindByIdAsync(query.Id);
            return AutoMapper.Mapper.Map<BranchViewModel>(branch);
        }
    }
}