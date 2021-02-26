using Microsoft.AspNetCore.Mvc;
using Product.Application.Models;
using System.Threading.Tasks;
using Product.Application.Queries;
using Product.Application.Commands;
using MediatR;
using System;

namespace Product.API.Controllers
{
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("GetAll")]   
        [HttpPost]
        public async Task<ProductViewModel[]> GetAll()
        {
            ProductViewModel[] productsList = await _mediator.Send(new ProductsListQuery());     
            return productsList;
        }

        [Route("FindById")]   
        [HttpPost]
        public async Task<ProductViewModel> FindById([FromBody] ProductFindByIdQuery model)
        {
            ProductViewModel role = await _mediator.Send(model);     
            return role;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<bool> Create([FromBody] CreateProductCommand model)
        {
            bool result = await _mediator.Send(model);
            return result;
        }

        [Route("Update")]
        [HttpPost]
        public async Task<bool> Update([FromBody] UpdateProductCommand model)
        {
            bool result = await _mediator.Send(model);
            return result;
        }
    }
}