using Application.Repositories.OrderRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetUserAllOrder
{
    public class GetUserAllOrderQueryHandler : IRequestHandler<GetUserAllOrderQueryRequest, List<GetUserAllOrderQueryResponse>>
    {
        private readonly IOrderReadRepository _OrderReadRepository;

        public GetUserAllOrderQueryHandler(IOrderReadRepository OrderReadRepository)
        {
            _OrderReadRepository = OrderReadRepository;
        }
        public async Task<List<GetUserAllOrderQueryResponse>> Handle(GetUserAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetUserAllOrderQueryResponse> responseList = new();

            var orders = await _OrderReadRepository.Table.Where(p => p.UserId == Guid.Parse(request.UserId)).ToListAsync();

            foreach (var p in orders)
            {
                responseList.Add(new GetUserAllOrderQueryResponse
                {
                    Id = p.Id,
                    Price = p.Price,
                    ProductId = p.ProductId,
                    UserId = p.UserId,

                });
            }
            return responseList;
        }
    }
}
