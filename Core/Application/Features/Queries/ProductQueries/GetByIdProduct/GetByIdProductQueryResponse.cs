using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public Guid Id;
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public int Stock { get; set; }
    }
}
