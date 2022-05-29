namespace Ates.Datas.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public abstract class ReadRepository<TEntity, TId> : Repository<TEntity, TId> where TEntity : class, IEntity<TId>
{
    public ReadRepository(DbContext context) : base(context)
    {
    }

    public virtual IQueryable<TEntity> GetAll()
    {
        return this.set.AsNoTracking();
    }

    public virtual async Task<TEntity> Get(Expression<Func<TEntity, Boolean>> filter)
    {
        if (filter is null)
        {
            throw new ArgumentNullException(nameof(filter));
        }

        var result = await this.GetAll().FirstOrDefaultAsync(filter);

        return result ?? throw new NullReferenceException();
    }

    public virtual async Task<TEntity> GetById(TId id)
    {
        if (id == null)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        var result = await this.GetAll().FirstOrDefaultAsync(e => e.Id.Equals(id));

        return result ?? throw new NullReferenceException();
    }
}
