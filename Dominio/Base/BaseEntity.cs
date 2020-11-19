namespace Dominio.Base
{
    public abstract class BaseEntity
    {
    }
    
    public abstract class Entity<T>: BaseEntity, IEntity<T>
    {
        public T Id { get; set; }
    }
}