namespace Ates.Datas;
public interface IEntity<TId>
{
    public TId Id { get; set; }
}
