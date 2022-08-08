using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetUserAllOrder
{
    public class GetUserAllOrderQueryRequest : IRequest<List<GetUserAllOrderQueryResponse>>
    {
        public string UserId { get; set; }
    }
}
