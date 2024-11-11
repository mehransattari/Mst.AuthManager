using Common.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using Mst.AuthManager.Domain.RoleAgg;
using Mst.AuthManager.Domain.UserAgg;

namespace Mst.AuthManager.Infrastructure.Persistent.Ef;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {            
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //For Entity Configuration
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    private List<AggregateRoot> GetModifiedEntities()
    {
        var result = ChangeTracker.Entries<AggregateRoot>()
        .Where(x => x.State != EntityState.Detached)
        .Select(c => c.Entity)
        .Where(c => c.DomainEvents.Any())
        .ToList();

        return result;
    }
 

  
}
