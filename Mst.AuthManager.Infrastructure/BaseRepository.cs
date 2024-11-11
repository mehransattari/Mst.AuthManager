using Common.Domain.Bases;
using Common.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Mst.AuthManager.Infrastructure.Persistent.Ef;
using System.Linq.Expressions;

namespace Mst.AuthManager.Infrastructure;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    public BaseRepository(ApplicationDbContext context)
    {
        Context = context;
        DbSet = Context.Set<TEntity>(); 
    }

    protected ApplicationDbContext Context { get; }
    protected DbSet<TEntity> DbSet { get; }  

    public virtual async Task<TEntity?> GetAsync(long id)
    {
        return await DbSet.FirstOrDefaultAsync(t => t.Id.Equals(id));
    }

    public async Task<TEntity?> GetTracking(long id)
    {
        return await DbSet.AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));
    }

    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    void IBaseRepository<TEntity>.Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public async Task AddRange(ICollection<TEntity> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public void Update(TEntity entity)
    {
        Context.Update(entity);
    }

    public async Task<int> Save()
    {
        return await Context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await DbSet.AnyAsync(expression);
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return DbSet.Any(expression);
    }

    public TEntity? Get(long id)
    {
        return DbSet.FirstOrDefault(t => t.Id.Equals(id));
    }
}
