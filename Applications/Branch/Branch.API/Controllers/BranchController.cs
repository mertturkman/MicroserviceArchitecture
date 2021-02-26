using Microsoft.AspNetCore.Mvc;
using Branch.Application.Models;
using System.Threading.Tasks;
using Branch.Application.Queries;
using Branch.Application.Commands;
using MediatR;

namespace Branch.API.Controllers
{
    [Route("api/Product")]
    public class BanchController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public BanchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("GetAll")]   
        [HttpPost]
        public async Task<BranchViewModel[]> GetAll()
        {
            BranchViewModel[] branchesList = await _mediator.Send(new BranchesListQuery());     
            return branchesList;
        }

        [Route("FindById")]   
        [HttpPost]
        public async Task<BranchViewModel> FindById([FromBody] BranchFindByIdQuery model)
        {
            BranchViewModel branch = await _mediator.Send(model);     
            return branch;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<bool> Create([FromBody] CreateBranchCommand model)
        {
            bool result = await _mediator.Send(model);
            return result;
        }

        [Route("Update")]
        [HttpPost]
        public async Task<bool> Update([FromBody] UpdateBranchCommand model)
        {
            bool result = await _mediator.Send(model);
            return result;
        }
    }
}