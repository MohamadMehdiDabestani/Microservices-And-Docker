using Mapster;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Order.Command.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepo _repo;

        public UpdateOrderCommandHandler(IOrderRepo repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repo.GetById(request.Id);

            if (order == null)
            {
                throw new NotFoundException("Order" , request.Id);
            }

            var orderUpdated = request.Adapt<Ordring.Domain.Entities.Order>();

            await _repo.Update(orderUpdated);
            return Unit.Value;
        }

    }
}
