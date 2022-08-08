using Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdProductQueryResponse response = new();
            response.Id = product.Id;
            response.Name = product.Name;
            response.Price = product.Price;
            response.Description = product.Description;
            response.CategoryId = product.CategoryId;
            response.UserId = product.UserId;
            response.Stock = product.Stock;

            return response;
        }
    }
}
