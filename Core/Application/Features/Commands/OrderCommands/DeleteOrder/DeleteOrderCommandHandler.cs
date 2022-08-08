using Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.OrderCommands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public DeleteOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.GetByIdAsync(request.Id);

            if (order is null)
            {
                return new DeleteOrderCommandResponse
                {
                    Message = "Order is null.",
                    Success = false
                };
            }

            _orderWriteRepository.Remove(order);

            var result = await _orderWriteRepository.SaveAsync() == 1 ? true : false;

            return new DeleteOrderCommandResponse
            {
                Message = result == true ? "Order is deleted" : "Order is not deleted",
                Success = result
            };

        }
    }
}
