using Npgsql;

namespace Discount.API.Data
{
    public class DiscountContext : IDiscountContext
    {

        public DiscountContext(IConfiguration config)
        {
            this.Connection = new NpgsqlConnection
                (config.GetValue<string>("DatabaseSettings:ConnectionString"));

            DiscountContextSeed.SeedData(this.Connection);
        }

        public NpgsqlConnection Connection { get; }
    }
}