namespace Ates.Datas.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

public abstract class WriteRepository<TEntity, TId> : Repository<TEntity, TId> where TEntity : class, IEntity<TId> where TId : notnull
{
    public WriteRepository(DbContext context) : base(context)
    {
    }

    public virtual async Task Insert(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _ = await this.set.AddAsync(entity);
    }

    public virtual async Task Delete(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _ = this.set.Remove(entity);
        await Task.CompletedTask;
    }

    public virtual async Task Update(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _ = this.set.Update(entity);
        await Task.CompletedTask;
    }

    public virtual async Task<Int32> Commit(CancellationToken cancellationToken = default)
    {
        return await this.context.SaveChangesAsync(cancellationToken);
    }
}
