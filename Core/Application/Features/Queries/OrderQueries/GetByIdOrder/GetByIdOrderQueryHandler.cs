using Application.Repositories.OrderRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetByIdOrder
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public GetByIdOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }
        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.Table
                .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdOrderQueryResponse response = new();
            response.Id = order.Id;
            response.Price = order.Price;
            response.ProductId = order.ProductId;
            response.UserId = order.UserId;
            
            return response;
        }
    }
}
