using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories.ProductRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.ProductRepository
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
