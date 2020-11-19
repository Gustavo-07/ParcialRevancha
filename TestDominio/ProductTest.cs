using System.Collections.Generic;
using Dominio.Domain;
using NUnit.Framework;

namespace TestDominio
{
    public class ProductTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /**
         * 
         */
        [Test]
        public void RetirarProductoSimpleConCantidadMayorAlExistente()
        {
            var simpleProduct = new Simple() { Id = 1, Name = "Pepsi", Quantity = 12, Type = "DirectSale", CostProduct = 2000m, PriceProduct = 5000m };
            var result = simpleProduct.TakeProduct(13);
            Assert.AreEqual($"No se puede retirar esta cantidad solo hay: {simpleProduct.Quantity}.",result);
        }
        
        [Test]
        public void RetirarProductoSimpleConCantidadMenorIgualAlExistente()
        {
            var simpleProduct = new Simple() { Id = 1, Name = "Pepsi", Quantity = 12, Type = "DirectSale", CostProduct = 2000m, PriceProduct = 5000m };
            var result = simpleProduct.TakeProduct(12);
            Assert.AreEqual($"Se vendieron 12 de: {simpleProduct.Name}", result);
        }
        
        [Test]
        public void RetirarProductoCompuestoCombo()
        {
            var simpleProduct = new Simple() { Id = 1, Name = "Pepsi", Quantity = 12, Type = "DirectSale", CostProduct = 2000m, PriceProduct = 5000m };
            var result = simpleProduct.TakeProduct(12);
            Assert.AreEqual($"Se vendieron 12 de: {simpleProduct.Name}", result);
        }
        
        [Test]
        public void RetirarProductoCompuestoSencilloValorCero()
        {
            var perroSencillo = PerroSencillo();
            var result = perroSencillo.TakeProduct(0);
            Assert.AreEqual("Para poder vender un producto la cantidad debe ser mayor a cero", result);
        }

        [Test]
        public void RetirarProductoCompuestoSencilloValorMayor()
        {
            var perroSencillo = PerroSencillo();
            var result = perroSencillo.TakeProduct(1);
            Assert.AreEqual($"Se vendieron 1 de: {perroSencillo.Name}", result);
        }
        
        [Test]
        public void RetirarProductoCompuestoComboValorMayor()
        {
            var comboAmigos = ComboAmigos();
            var result = comboAmigos.TakeProduct(1);
            Assert.AreEqual($"Se vendieron 1 de: {comboAmigos.Name}", result);
        }

        private static Compound PerroSencillo()
        {
            var lista = new List<Minuta>();
            lista.AddRange(new []
            {
                new Minuta() { Product = new Simple() { Id = 1, Quantity = 12, Name = "Pan de perro", Type = "Prepared", CostProduct = 1000m, PriceProduct = 0m}, Quantity = 1, Id = 1},
                new Minuta() { Product = new Simple() { Id = 2, Quantity = 12, Name = "Queso Suizo", Type = "Prepared", CostProduct = 1000m, PriceProduct = 0m}, Quantity = 1, Id = 2},
                new Minuta() { Product = new Simple() { Id = 3, Quantity = 12, Name = "salchicha", Type = "Prepared", CostProduct = 1000m, PriceProduct = 0m}, Quantity = 1, Id = 3}, 
            });
            return new Compound() { Id = 1, Name = "Perro Sencillo", Ingredients = lista, CostProduct = 0m, Type = "Sencillo", PriceProduct = 5000m };
        }

        private static Compound SuperPerro()
        {
            var lista = new List<Minuta>();
            lista.AddRange(new []
            {
                new Minuta() { Product = new Simple() { Id = 1, Quantity = 12, Name = "Pan de perro", Type = "Prepared", CostProduct = 1000m, PriceProduct = 0m}, Quantity = 1, Id = 1},
                new Minuta() { Product = new Simple() { Id = 2, Quantity = 12, Name = "Queso Suizo", Type = "Prepared", CostProduct = 1000m, PriceProduct = 0m}, Quantity = 2, Id = 2},
                new Minuta() { Product = new Simple() { Id = 3, Quantity = 12, Name = "salchicha ranchera", Type = "Prepared", CostProduct = 1000m, PriceProduct = 0m}, Quantity = 1, Id = 3}, 
            });
            return new Compound() { Id = 1, Name = "Super Perro", Ingredients = lista, CostProduct = 0m, Type = "Sencillo", PriceProduct = 5000m };
        }

        private static Compound ComboAmigos()
        {
            var lista = new List<Minuta>();
            lista.AddRange(new[]
            {
                new Minuta() {Product = SuperPerro(), Quantity = 2, Id = 1},
                new Minuta()
                {
                    Product = new Simple()
                    {
                        Id = 1, Quantity = 12, Name = "Pepsi", Type = "DirectSale", CostProduct = 2000m,
                        PriceProduct = 5000m
                    },
                    Quantity = 1,
                    Id = 2
                }
            });
            return new Compound() { Id = 1, Ingredients = lista, Name = "Combo Amigos", Type = "Combo", };
        }
    }
}