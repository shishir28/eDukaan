using Npgsql;
using Dapper;

namespace Discount.Grpc.Data
{
    public class DiscountContextSeed
    {
        public static void SeedData(NpgsqlConnection connection)
        {
            var tableCount = connection.QueryFirst<int>(@"SELECT  COUNT(table_name)
                                                                            FROM
                                                                                information_schema.tables
                                                                            WHERE
                                                                                table_schema LIKE 'public' AND
                                                                                table_type LIKE 'BASE TABLE' AND
                                                                                table_name = 'coupon'; ");
            if (tableCount <= 0)
            {
                connection.Execute(@"CREATE TABLE Coupon(
                                                ID SERIAL PRIMARY KEY         NOT NULL,
                                                ProductName     VARCHAR(24) NOT NULL,
                                                Description     TEXT,
                                                Amount          INT
                                            );");

                connection.Execute("INSERT INTO Coupon  (ProductName, Description, Amount) VALUES (@productName, @description, @amount)", new
                {
                    productName = "IPhone X",
                    description = "IPhone Discount",
                    amount = 150
                });

                connection.Execute("INSERT INTO Coupon  (ProductName, Description, Amount) VALUES (@productName, @description, @amount)", new
                {
                    productName = "Samsung 10",
                    description = "Samsung Discount",
                    amount = 100
                });

            }
        }
    }
}