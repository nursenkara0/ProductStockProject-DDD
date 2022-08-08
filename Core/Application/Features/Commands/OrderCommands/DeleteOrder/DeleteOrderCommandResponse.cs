using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.OrderCommands.DeleteOrder
{
    public class DeleteOrderCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
