using Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public DeleteProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                return new DeleteProductCommandResponse
                {
                    Message = "Product is null.",
                    Success = false
                };
            }

            _productWriteRepository.Remove(product);

            var result = await _productWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteProductCommandResponse
            {
                Message = result == true ? "Product is deleted" : "Product is not deleted",
                Success = result
            };

        }
    }
}
