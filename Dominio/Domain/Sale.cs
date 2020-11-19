using Dominio.Base;

namespace Dominio.Domain
{
    public class Sale: Entity<int>
    {
        public Product Product { get; set; }
        public decimal QuantitySale { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalSale { get; set; }
        
        public Sale() {}
    }
}