using Ordring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderingContext context )
        {
            if(!context.Orders.Any())
            {
                await context.Orders.AddRangeAsync(GetOrdersForSeed());
                await context.SaveChangesAsync();
            }
        }
        public static IEnumerable<Order> GetOrdersForSeed()
        {
            return new List<Order>
            {
                new Order() {UserName = "swn", FirstName = "Mehmet", LastName = "Ozkaya", EmailAddress = "ezozkme@gmail.com", AddressLine = "Bahcelievler", Country = "Turkey", TotalPrice = 350 }
            };
        }
    }
}
