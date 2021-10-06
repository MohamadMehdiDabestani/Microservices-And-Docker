using Microsoft.EntityFrameworkCore;
using Ordring.Domain.Common;
using Ordring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Infrastructure
{
    public class OrderingContext : DbContext
    {
        public OrderingContext(DbContextOptions<OrderingContext> opt):base(opt)
        {

        }
        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<EntityBase>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.LastModifyedDate = DateTime.Now;
                        item.Entity.LastModifyedBy = "user name";
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.Now;
                        item.Entity.CreatedBy = "user name";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
