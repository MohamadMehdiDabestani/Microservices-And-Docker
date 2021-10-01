using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Order.Query.GetOrderList
{
    public class GetOrderList : IRequest<List<OrderVm>>
    {
        public string UserName { get; set; }

        public GetOrderList(string userName)
        {
            UserName = userName;
        }
    }
}
