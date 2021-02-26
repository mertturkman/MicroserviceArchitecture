using System.Runtime.Serialization;
using Product.Application.Models;
using MediatR;

namespace Product.Application.Queries
{
    [DataContract]
    public class ProductsListQuery : IRequest<ProductViewModel[]>
    {
        
    }
}