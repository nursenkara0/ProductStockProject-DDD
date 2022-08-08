using Application.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;

        public DeleteUserCommandHandler(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }
        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                return new DeleteUserCommandResponse
                {
                    Message = "User is null.",
                    Success = false
                };
            }

            _userWriteRepository.Remove(user);

            var result = await _userWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteUserCommandResponse
            {
                Message = result == true ? "User is deleted" : "User is not deleted",
                Success = result
            };

        }
    }
}
