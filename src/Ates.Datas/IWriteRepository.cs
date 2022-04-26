namespace Ates.Datas;
public interface IWriteRepository<TEntity> where TEntity : class, IEntity
{
    public Task Insert(TEntity entity);
    public Task Update(TEntity entity);
    public Task Delete(TEntity entity);
    public Task<Int32> Commit();
}
