namespace Ates.Datas.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public abstract class ReadRepository<TEntity, TId> : Repository<TEntity, TId> where TEntity : class, IEntity<TId> where TId : notnull
{
    public ReadRepository(DbContext context) : base(context)
    {
    }

    public virtual IQueryable<TEntity> GetAll(Boolean tracking = true)
    {
        var query = this.set.AsQueryable();
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }

    public virtual async Task<TEntity?> Get(Expression<Func<TEntity, Boolean>> filter, Boolean tracking = true)
    {
        if (filter is null)
        {
            throw new ArgumentNullException(nameof(filter));
        }
        return await this.GetAll(tracking).FirstOrDefaultAsync(filter);
    }

    public virtual async Task<TEntity?> GetById(TId id, Boolean tracking = true)
    {
        if (id == null)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }
        return await this.Get(entity => entity.Id.Equals(id), tracking);
    }
}
