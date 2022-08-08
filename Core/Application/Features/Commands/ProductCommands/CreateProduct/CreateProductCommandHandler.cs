using Application.Repositories.ProductRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Product product = new Product
            {
                Id = id,
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                CategoryId = request.CategoryId,
                UserId = request.UserId,
                Stock = request.Stock,
            };

            var result = await _productWriteRepository.AddAsync(product);

            await _productWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateProductCommandResponse { Success = result, Message = result ? "Product is created successfully" : "Product creation is failed" };
        }
    }
}
