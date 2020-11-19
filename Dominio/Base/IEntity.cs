namespace Dominio.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}