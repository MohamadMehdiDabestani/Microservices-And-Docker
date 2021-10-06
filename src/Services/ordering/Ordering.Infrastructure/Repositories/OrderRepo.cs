using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistance;
using Ordering.Infrastructure.Persistence;
using Ordring.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepo : RepositoryBase<Order>, IOrderRepo
    {

        public OrderRepo(OrderingContext db) : base(db)
        {

        }
        public async Task<IEnumerable<Order>> GetOrderByUsername(string userName)
        {
            return await db.Orders.Where(o => o.UserName == userName).ToListAsync();
        }
    }
}
