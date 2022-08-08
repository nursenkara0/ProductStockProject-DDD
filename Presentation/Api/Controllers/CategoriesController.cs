using Application.Features.Commands.CategoryCommands.CreateCategory;
using Application.Features.Commands.CategoryCommands.DeleteCategory;
using Application.Features.Commands.CategoryCommands.UpdateCategory;
using Application.Features.Queries.CategoryQueries.GetAllCategories;
using Application.Features.Queries.CategoryQueries.GetByIdCategory;
using Application.Features.Queries.CategoryQueries.SearchCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllCategoryQueryResponse>> GetCategories()
        {
            return await _mediator.Send(new GetAllCategoryQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdCategoryQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdCategoryQueryRequest { Id = id });
        }


        [HttpPost]
        public async Task<CreateCategoryCommandResponse> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateCategoryCommandResponse> UpdateCategory([FromForm] UpdateCategoryCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteCategoryCommandResponse> DeleteCategory(string id)
        {
            return await _mediator.Send(new DeleteCategoryCommandRequest { Id = id });
        }

    }
}
