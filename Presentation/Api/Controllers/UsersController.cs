using Application.Features.Commands.UserCommands.CreateUser;
using Application.Features.Commands.UserCommands.DeleteUser;
using Application.Features.Commands.UserCommands.UpdateUser;
using Application.Features.Queries.UserQueries.GetAllUsers;
using Application.Features.Queries.UserQueries.GetByIdUser;
using Application.Repositories.UserRepository;
using Infrastructure.JwtHelpers;
using Infrastructure.JwtModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IMediator _mediator;
        private readonly JwtSettings _jwtSettings;
        private readonly IUserReadRepository _userReadRepository;

        public UsersController(IMediator mediator, JwtSettings jwtSettings, IUserReadRepository userReadRepository)
        {
            _mediator = mediator;
            _jwtSettings = jwtSettings;
            _userReadRepository = userReadRepository;
        }

        [HttpGet]
        public async Task<List<GetAllUserQueryResponse>> GetUsers()
        {
            return await _mediator.Send(new GetAllUserQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdUserQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdUserQueryRequest { Id = id });
        }

        [HttpPost]
        public async Task<CreateUserCommandResponse> CreateUser([FromBody] CreateUserCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateUserCommandResponse> UpdateUser([FromForm] UpdateUserCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteUserCommandResponse> DeleteUser(string id)
        {
            return await _mediator.Send(new DeleteUserCommandRequest { Id = id });
        }

        [HttpPost("Login")]
        public IActionResult Login(UserLogins userLogins)
        {
            var user = _userReadRepository.Authenticate(userLogins.Email, Application.Helpers.Md5.Hash(userLogins.Password));
            if (user == null)
            {
                return NotFound("User is not found");
            }
            UserTokens Token = JwtHelpers.GenTokenkey(new UserTokens()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Surname = user.Surname,
                GuidId = Guid.NewGuid(),
            }, _jwtSettings);

            return Ok(Token);

        }
    }
}
