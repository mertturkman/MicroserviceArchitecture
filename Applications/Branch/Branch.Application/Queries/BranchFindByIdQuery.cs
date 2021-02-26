using System;
using System.Runtime.Serialization;
using Branch.Application.Models;
using MediatR;

namespace Branch.Application.Queries
{
    public class BranchFindByIdQuery : IRequest<BranchViewModel>
    {
        [DataMember]
        public Guid Id { get; private set; }

        public BranchFindByIdQuery(Guid id)
        {
            Id = id;
        }

    }
}