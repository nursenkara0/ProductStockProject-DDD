using Application.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;

        public UpdateUserCommandHandler(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {

            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return new UpdateUserCommandResponse
                {
                    Success = false,
                    Message = "User is not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateUserCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            user.Name = request.Name ?? user.Name;
            user.Surname = request.Surname ?? user.Surname;
            user.Email = request.Email ?? user.Email;
            user.Password = request.Password ?? user.Password;

            user.Password = Helpers.Md5.Hash(user.Password);

            _userWriteRepository.Update(user);

            await _userWriteRepository.SaveAsync();

            return new UpdateUserCommandResponse
            {
                Success = true,
                Message = "User is updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateUserCommandRequest request)
        {
            if (request.Name == null &&
                request.Surname == null &&
                request.Email == null &&
                request.Password == null)
            {
                return true;
            }

            return false;
        }
    }
}
