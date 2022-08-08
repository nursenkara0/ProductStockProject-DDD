using Application.Repositories.OrderRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<GetAllOrderQueryResponse>>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }
        public async Task<List<GetAllOrderQueryResponse>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllOrderQueryResponse> responseList = new();

            var orders = await _orderReadRepository.Table
                .ToListAsync()
                ;

            foreach (var o in orders)
            {
                responseList.Add(new GetAllOrderQueryResponse
                {
                    Id = o.Id,
                    Price = o.Price,
                    ProductId = o.ProductId,
                    UserId = o.UserId
                });
            }
            return responseList;
        }
    }
}
