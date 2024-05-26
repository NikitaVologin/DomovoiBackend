namespace DomovoiBackend.Domain.Abstraction;

public abstract class UpdatableEntity<TEntity> where TEntity : UpdatableEntity<TEntity>
{
    public abstract void Update(TEntity entity);
}