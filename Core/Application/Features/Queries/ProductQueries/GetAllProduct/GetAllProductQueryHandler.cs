using Application.Repositories.ProductRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllProductQueryResponse> responseList = new();

            var products = await _productReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in products)
            {
                responseList.Add(new GetAllProductQueryResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    UserId = p.UserId,
                    Stock = p.Stock,
                });
            }
            return responseList;
        }
    }
}
