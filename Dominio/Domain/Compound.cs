using System.Collections.Generic;

namespace Dominio.Domain
{
    public class Compound: Product
    {
        public List<Minuta> Ingredients { get; set; }

        public Compound()
        {
            Ingredients = new List<Minuta>();
        }
        
        public override string TakeProduct(int quantity)
        {
            if (quantity <= 0) return "Para poder vender un producto la cantidad debe ser mayor a cero";
            for (var i = 0; i < quantity; i++)
            {
                Ingredients.ForEach(delegate(Minuta minuta)
                {
                    minuta.Product.TakeProduct(minuta.Quantity);
                });
            }
            SaleProduct.Add(new Sale()
            {
                Product = this,
                QuantitySale = quantity,
                TotalCost = (Cost() * quantity),
                TotalSale = (Price() * quantity)
            });
            return $"Se vendieron {quantity} de: {Name}";
        }
        
        public override decimal Price()
        {
            return PriceProduct;
        }

        public override decimal Cost()
        {
            Ingredients.ForEach(delegate(Minuta minuta)
           {
               CostProduct += minuta.Product.Cost() * minuta.Quantity;
           });
           return CostProduct;
        }

        public string AddMinuta(Product product, int quantity)
        {
            if (quantity <= 0) return "La cantidad debe ser mayor a 0 para la minuta";
            Ingredients.Add(new Minuta(){ Product = product, Quantity = quantity});
            return "Se agrego un nuevo ingrediente al producto";
        }
    }
}