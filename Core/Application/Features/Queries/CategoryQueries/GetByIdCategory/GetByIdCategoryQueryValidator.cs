using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryValidator : AbstractValidator<GetByIdCategoryQueryRequest>
    {
        public GetByIdCategoryQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
