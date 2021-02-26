using System.Runtime.Serialization;
using Branch.Application.Models;
using MediatR;

namespace Branch.Application.Queries
{
    [DataContract]
    public class BranchesListQuery : IRequest<BranchViewModel[]>
    {
        
    }
}