namespace Dominio.Domain
{
    public interface IProduct
    {
        string TakeProduct(int quantity);
        decimal Utility();
        decimal Price();
        decimal Cost();
    }
}