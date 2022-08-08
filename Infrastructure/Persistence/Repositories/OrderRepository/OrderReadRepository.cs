using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories.OrderRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.OrderRepository
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
