using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<EntityBase>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.CreatedDate = DateTime.UtcNow;
                        item.Entity.CreatedBy = "skm";

                        break;
                    case EntityState.Modified:
                        item.Entity.LastModifiedDate = DateTime.UtcNow;
                        item.Entity.LastModifiedBy = "skm";

                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}