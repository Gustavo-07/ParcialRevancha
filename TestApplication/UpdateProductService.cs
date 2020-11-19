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
            var optionsInMemory = new DbContextOptionsBuilder<ProductContext>().UseInMemoryDatabase("Input").Options;
            _context = new ProductContext(optionsInMemory);
        }

        [Test]
        public void InputProduct()
        {
            var request = new InputRequest { Nombre = "Gaseosa", Cantidad = 3};
            InputService _service = new InputService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual($"Su cantidad es {request.Cantidad}.", response.Mensaje);
        }
    }
}