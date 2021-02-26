using System.Threading;
using System.Threading.Tasks;
using Branch.Application.Models;
using Branch.Domain.AggregatesModel.BranchAggregate;
using MediatR;

namespace Branch.Application.Queries
{
    public class BranchesListQueryHandler : IRequestHandler<BranchesListQuery, BranchViewModel[]>
    {
        
        private readonly IBranchRepository _branchRepository;

        public BranchesListQueryHandler(IBranchRepository branchRepository)
        {
           _branchRepository = branchRepository;
        }

        public async Task<BranchViewModel[]> Handle(BranchesListQuery query, CancellationToken cancellationToken)
        {
            Branch.Domain.AggregatesModel.BranchAggregate.Branch[] branchList = await _branchRepository.GetAllAsync();
            return AutoMapper.Mapper.Map<BranchViewModel[]>(branchList);
        }

    }
}