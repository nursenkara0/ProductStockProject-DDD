using Application.Repositories.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.UserQueries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, List<GetAllUserQueryResponse>>
    {
        private readonly IUserReadRepository _userReadRepository;

        public GetAllUserQueryHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }
        public async Task<List<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllUserQueryResponse> responseList = new();

            var users = await _userReadRepository.Table
                .ToListAsync()
                ;

            foreach (var p in users)
            {
                responseList.Add(new GetAllUserQueryResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Email,
                    // Password = p.Password
                });
            }
            return responseList;
        }
    }
}
