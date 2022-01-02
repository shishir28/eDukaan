using Npgsql;

namespace Discount.Grpc.Data
{
    public interface IDiscountContext
    {
        NpgsqlConnection Connection { get; }
    }
}