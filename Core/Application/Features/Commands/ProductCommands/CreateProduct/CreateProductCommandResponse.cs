using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
