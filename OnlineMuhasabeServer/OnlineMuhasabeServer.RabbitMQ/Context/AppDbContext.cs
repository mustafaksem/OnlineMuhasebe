using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasabeServer.RabbitMQ.Context
{
    public class AppDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-LQOAMHU\\SQLEXPRESS;Initial Catalog=MuhasebeMasterDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Company> Companies { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedDate)
                        .CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdatedDate)
                        .CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
