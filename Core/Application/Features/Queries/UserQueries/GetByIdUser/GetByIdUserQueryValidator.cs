using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.UserQueries.GetByIdUser
{
    public class GetByIdUserQueryValidator : AbstractValidator<GetByIdUserQueryRequest>
    {
        public GetByIdUserQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }
}
