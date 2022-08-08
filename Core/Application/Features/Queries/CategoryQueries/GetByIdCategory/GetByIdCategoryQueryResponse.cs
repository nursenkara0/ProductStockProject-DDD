using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryResponse
    {
        public Guid Id;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
