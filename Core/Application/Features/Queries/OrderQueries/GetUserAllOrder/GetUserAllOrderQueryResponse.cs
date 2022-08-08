using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.OrderQueries.GetUserAllOrder
{
    public class GetUserAllOrderQueryResponse
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
