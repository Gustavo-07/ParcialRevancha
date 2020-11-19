using Application.SimpleProduct;
using Infrastructura.Base;
using Infrastructura.Contexts;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TestApplication
{
    public class UpdateProductService
    {
        ProductContext _context;
        
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase("Product").Options;
            _context = new ProductContext(optionsInMemory);
        }

        [Test]
        public void AddProduct()
        {
            var request = new AddDirectSaleRequest { Name = "Gaseosa", Cost = 2000, Quantity = 7};
            AddSimpleProductService _service = new AddSimpleProductService(new UnitOfWork(_context));
            var response = _service.AddDirectSale(request);
            Assert.AreEqual("Registro exitoso, hay en existencia 7 productos", response.Message);
        }
    }
}