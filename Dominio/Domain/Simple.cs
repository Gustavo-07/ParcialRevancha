namespace Dominio.Domain
{
    public class Simple: Product
    {
        public int Quantity { get; set; }

        public Simple()
        {
            PriceProduct = 0m;
            CostProduct = 0m;
        }

        public string InputQuantity(int quantity)
        {
            if (quantity <= 0) return "Para poder registrar un producto la cantidad debe ser mayor a cero";
            Quantity += quantity;
            return $"Registro exitoso, hay en existencia {Quantity} productos";
        }
        
        public override string TakeProduct(int quantity)
        {
            if (Quantity < quantity) return $"No se puede retirar esta cantidad solo hay: {Quantity}.";
            Quantity -= quantity;
            SaleProduct.Add(new Sale()
            {
                Product = this, 
                QuantitySale = quantity,
                TotalCost = (CostProduct * quantity), 
                TotalSale = (PriceProduct * quantity)
            });
            return $"Se vendieron {quantity} de: {Name}";
        }
        
        public override decimal Price()
        {
            return PriceProduct;
        }

        public override decimal Cost()
        {
            return CostProduct;
        }
    }
}