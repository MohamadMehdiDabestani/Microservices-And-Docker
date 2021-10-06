using Mapster;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Order.Query.GetOrderList
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrderList, List<OrderVm>>
    {
        private readonly IOrderRepo _order;
        

        public GetOrderListQueryHandler(IOrderRepo order)
        {
            _order = order;
        }

        public async Task<List<OrderVm>> Handle(GetOrderList request, CancellationToken cancellationToken)
        {
            var list = await _order.GetOrderByUsername(request.UserName);
            return list.Adapt<List<OrderVm>>();
        }

    }
}
