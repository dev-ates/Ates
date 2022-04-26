namespace Ates.Datas;

using Microsoft.EntityFrameworkCore;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly DbContext context;
    protected readonly DbSet<TEntity> set;

    public Repository(DbContext context)
    {
        this.context = context;
        this.set = context.Set<TEntity>();
    }
}
