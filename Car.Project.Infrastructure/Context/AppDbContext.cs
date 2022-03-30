using CarProject.Domain.Entities;
using CarProject.Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarProject.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Boat> Boats { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            DateTime dateTime = DateTime.Now;
            foreach (var item in modifiedEntries)
            {
                var entity = item.Entity as Vehicle;

                if (entity != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedDate = dateTime;
                        entity.IsActive = true;
                        
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedDate = dateTime;
                    }
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
