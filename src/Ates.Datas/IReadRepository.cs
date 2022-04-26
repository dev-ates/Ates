namespace Ates.Datas;

using System.Linq.Expressions;

public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    public IQueryable<TEntity> GetAll();
    public Task<TEntity> Get(Expression<Func<TEntity, Boolean>> filter);
    public Task<TEntity> GetById(Guid id);
}
