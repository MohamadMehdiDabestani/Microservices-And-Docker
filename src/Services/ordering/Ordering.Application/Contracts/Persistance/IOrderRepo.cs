using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordring.Domain.Entities;
namespace Ordering.Application.Contracts.Persistance
{
    public interface IOrderRepo : IAsyncRepo<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUsername(string userName);
    }
}
