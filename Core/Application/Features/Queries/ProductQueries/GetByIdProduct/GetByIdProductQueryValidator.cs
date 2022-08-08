using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryValidator : AbstractValidator<GetByIdProductQueryRequest>
    {
        public GetByIdProductQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
