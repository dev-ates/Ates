namespace Ates.Datas.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;

public abstract class Repository<TEntity, TId> where TEntity : class, IEntity<TId> where TId : notnull
{
    protected readonly DbContext context;
    protected readonly DbSet<TEntity> set;

    public Repository(DbContext context)
    {
        this.context = context;
        this.set = context.Set<TEntity>();
    }
}
