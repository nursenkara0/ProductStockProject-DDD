using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrderQueryRequest : IRequest<List<GetAllOrderQueryResponse>>
    {
    }
}
