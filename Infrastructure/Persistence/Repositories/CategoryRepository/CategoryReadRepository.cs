using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Repositories.CategoryRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.CategoryRepository
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
