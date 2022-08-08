using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
