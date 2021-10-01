using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IOrderRepo order, IMapper mapper)
        {
            _order = order;
            _mapper = mapper;
        }

        public async Task<List<OrderVm>> Handle(GetOrderList request, CancellationToken cancellationToken)
        {
            var list = await _order.GetOrderByUsername(request.UserName);
            return _mapper.Map<List<OrderVm>>(list);
        }

    }
}
