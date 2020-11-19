using System.Collections.Generic;
using Dominio.Base;

namespace Dominio.Domain
{
    public abstract class Product: Entity<int>, IProduct
    {
        public Product()
        {
            SaleProduct = new List<Sale>();
        }
        public List<Sale> SaleProduct { get; set; }
        public string Name { get; set; }
        public decimal CostProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public string Type { get; set; }

        public abstract string TakeProduct(int quantity);

        public virtual decimal Utility()
        {
            return Price() - Cost();
        }
        public abstract decimal Price();
        public abstract decimal Cost();
    }
}