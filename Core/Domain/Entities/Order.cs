using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public decimal Price { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
