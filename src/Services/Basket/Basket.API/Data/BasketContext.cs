using Basket.API.Entites;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Data
{
    public class BasketContext : DbContext
    {
        public BasketContext(DbContextOptions<BasketContext> opt) : base(opt)
        {

        }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
    }
}
