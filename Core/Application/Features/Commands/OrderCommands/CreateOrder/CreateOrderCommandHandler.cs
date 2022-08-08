using Application.Repositories.OrderRepository;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.OrderCommands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {

            var id = Guid.NewGuid();
            Order order = new Order
            {
                Id = id,
                Price = request.Price,
                ProductId = request.ProductId,
                UserId = request.UserId
            };

            var result = await _orderWriteRepository.AddAsync(order);

            await _orderWriteRepository.SaveAsync();//== 1 ? true : false;

            return new CreateOrderCommandResponse { Success = result, Message = result ? "Order is created successfully" : "Order creation is failed" };
        }
    }
}
