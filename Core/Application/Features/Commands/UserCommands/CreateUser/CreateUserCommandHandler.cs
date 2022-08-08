using Application.Repositories.UserRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;

        public CreateUserCommandHandler(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }
        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var email = await _userReadRepository.GetSingleAsync(p => p.Email == request.Email);

            if (email is not null)
            {
                return new CreateUserCommandResponse()
                {
                    Success = false,
                    Message = "Email is already exists"
                };
            }

            var id = Guid.NewGuid();
            User user = new User
            {
                Id = id,
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Password = Helpers.Md5.Hash(request.Password)
            };

            var result = await _userWriteRepository.AddAsync(user);

            await _userWriteRepository.SaveAsync();

            return new CreateUserCommandResponse { Success = result, Message = result ? "User is created successfully" : "User creation is failed" };
        }
    }
}
