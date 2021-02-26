using System;
using System.Runtime.Serialization;
using Product.Application.Models;
using MediatR;

namespace Product.Application.Queries
{
    public class ProductFindByIdQuery : IRequest<ProductViewModel>
    {
        [DataMember]
        public Guid Id { get; private set; }

        public ProductFindByIdQuery(Guid id)
        {
            this.Id = id;
        }

    }
}