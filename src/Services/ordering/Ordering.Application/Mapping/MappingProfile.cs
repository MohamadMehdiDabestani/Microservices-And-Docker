using AutoMapper;
using Ordering.Application.Features.Order.Command.CheckoutOrder;
using Ordering.Application.Features.Order.Command.UpdateOrder;
using Ordering.Application.Features.Order.Query.GetOrderList;
using Ordring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderVm>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}
