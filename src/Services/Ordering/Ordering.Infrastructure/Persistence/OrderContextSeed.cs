using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext context)//, ILogger<OrderContextSeed> logger)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(GetPreConfiguredOrders());
                await context.SaveChangesAsync();
                //logger.LogInformation("Seeding initial order data completed.");
            }
        }

        private static IEnumerable<Order> GetPreConfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "skm",
                FirstName = "Shishir",
                LastName = "Mishra",
                EmailAddress = "shishir28@gmail.com",
                AddressLine = "Test",
                Country = "Australia",
                State = "NSW",
                ZipCode = "2145",
                CardName = "Australia",
                CardNumber = "123456789",
                Expiration = "12/12",
                CVV = "123",
                TotalPrice = 350 }
            };
        }
    }
}
