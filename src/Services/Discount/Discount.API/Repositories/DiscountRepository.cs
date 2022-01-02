using Dapper;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        public DiscountRepository(IConfiguration configuration) =>
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        public async Task<Coupon> GetDiscount(string productName)
        {

            using var connection = new NpgsqlConnection
                 (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(
          "SELECT * FROM Coupon  WHERE ProductName  = @productName",
          new { productName });

            if (coupon == null)
                return new Coupon { ProductName = productName, Amount = 0, Description = "No discount description" };
            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var result = await connection.ExecuteAsync("INSERT INTO Coupon  (ProductName, Description, Amount) VALUES (@productName, @description, @amount)", new
            {
                productName = coupon.ProductName,
                description = coupon.Description,
                amount = coupon.Amount
            });

            return result > 0;

        }
        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection
               (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var result = await connection.ExecuteAsync
                    ("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id", new
                    {
                        ProductName = coupon.ProductName,
                        Description = coupon.Description,
                        Amount = coupon.Amount,
                        Id = coupon.Id
                    });

            return result > 0;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {

            using var connection = new NpgsqlConnection
              (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var result = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @productName", new { productName = productName });

            return result > 0;

        }
    }
}