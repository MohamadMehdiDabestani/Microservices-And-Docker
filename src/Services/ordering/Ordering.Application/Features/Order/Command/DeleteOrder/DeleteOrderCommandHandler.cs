using MediatR;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Order.Command.DeleteOrder
{
    class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepo _order;

        public DeleteOrderCommandHandler(IOrderRepo order)
        {
            _order = order;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _order.GetById(request.Id);
            if (order == null)
            {
                throw new NotFoundException("Order" , request.Id);
            }
            await _order.Delete(order);

            return Unit.Value;

        }
    }
}
