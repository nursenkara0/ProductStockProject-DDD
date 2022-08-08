using Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.OrderCommands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public UpdateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {

            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.GetByIdAsync(request.Id);
            if (order == null)
            {
                return new UpdateOrderCommandResponse
                {
                    Success = false,
                    Message = "Order is not found"
                };
            }

            if (CheckRequestIsEmpty(request))
            {
                return new UpdateOrderCommandResponse
                {
                    Success = false,
                    Message = "Request is empty"
                };
            }

            order.Price = request.Price ?? order.Price;
            order.ProductId = request.ProductId ?? order.ProductId;
            order.UserId = request.UserId ?? order.UserId;

            _orderWriteRepository.Update(order);

            await _orderWriteRepository.SaveAsync();

            return new UpdateOrderCommandResponse
            {
                Success = true,
                Message = "Order is updated successfully"
            };
        }

        private bool CheckRequestIsEmpty(UpdateOrderCommandRequest request)
        {
            if (request.Price == null &&
                request.ProductId == null &&
                request.UserId == null)
            {
                return true;
            }

            return false;
        }
    }
}
