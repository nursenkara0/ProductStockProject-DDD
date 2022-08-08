using Application.Features.Commands.ProductCommands.CreateProduct;
using Application.Features.Commands.ProductCommands.DeleteProduct;
using Application.Features.Commands.ProductCommands.UpdateProduct;
using Application.Features.Queries.ProductQueries.GetAllProducts;
using Application.Features.Queries.ProductQueries.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllProductQueryResponse>> GetProducts()
        {
            return await _mediator.Send(new GetAllProductQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdProductQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdProductQueryRequest { Id = id });
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<CreateProductCommandResponse> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateProductCommandResponse> UpdateProduct([FromForm] UpdateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteProductCommandResponse> DeleteProduct(string id)
        {
            return await _mediator.Send(new DeleteProductCommandRequest { Id = id });
        }

    }
}
