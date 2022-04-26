namespace Ates.Datas;

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public abstract class ReadRepository<TEntity> : Repository<TEntity>, IReadRepository<TEntity> where TEntity : class, IEntity
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

    public virtual async Task<TEntity> GetById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        var result = await this.GetAll().FirstOrDefaultAsync(e => e.Id == id);

        return result ?? throw new NullReferenceException();
    }
}
