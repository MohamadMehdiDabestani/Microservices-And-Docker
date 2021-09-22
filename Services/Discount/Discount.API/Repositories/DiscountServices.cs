using Discount.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Dapper;
namespace Discount.API.Repositories
{
    public class DiscountServices : IDiscountServices
    {
        private readonly IConfiguration config;

        public DiscountServices(IConfiguration config)
        {
            this.config = config;
        }
        public async Task<bool> CreateCoupon(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var add = await
                connection.ExecuteAsync("insert into Coupon (ProductName , Description , Amount) VALUES (@ProductName , @Description , @Amount)" , 
                new { ProductName = coupon.ProductName, Description= coupon.Description, Amount = coupon.Amount});
            if (add == 0)
                return false;
            return true;
        }

        public async Task<bool> DeleteCoupon(string productname)
        {
            using var connection = new NpgsqlConnection(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var query = await
                connection.ExecuteAsync("Delete from Coupon where ProductName = @productname",
                new { productname });
            if (query == 0)
                return false;
            return true;
        }

        public async Task<Coupon> GetCoupon(string productname)
        {
            using var connection = new NpgsqlConnection(config.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("select * from Coupon where ProductName = @productname"
                , new {productname});
            if(coupon == null)
            {
                return new Coupon()
                {
                    Amount = 0,
                    Description = "No Discount Description",
                    ProductName = "No Coupon"
                };
            }
            return coupon;
        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var query = await
                connection.ExecuteAsync("update Coupon SET ProductName=@ProductName , Description=@Description , Amount=@Amount where Id = @Id" 
                ,coupon);
            if (query == 0)
                return false;
            return true;
        }
    }
}
