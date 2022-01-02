using Dapper;
using Discount.API.Data;
using Discount.API.Entities;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IDiscountContext _context;
        public DiscountRepository(IDiscountContext context) =>
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<Coupon> GetDiscount(string productName)
        {
            var coupon = await _context.Connection.QueryFirstOrDefaultAsync<Coupon>(
          "SELECT * FROM Coupon  WHERE ProductName  = @productName",
          new { productName });

            if (coupon == null)
                return new Coupon { ProductName = productName, Amount = 0, Description = "No discount description" };
            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            var result = await _context.Connection.ExecuteAsync("INSERT INTO Coupon  (ProductName, Description, Amount) VALUES (@productName, @description, @amount)", new
            {
                productName = coupon.ProductName,
                description = coupon.Description,
                amount = coupon.Amount
            });

            return result > 0;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var result = await _context.Connection.ExecuteAsync
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
            var result = await _context.Connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @productName", new { productName = productName });
            return result > 0;
        }
    }
}