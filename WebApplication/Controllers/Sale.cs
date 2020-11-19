using Application.SaleProduct;
using Dominio.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<SaleProductResponse> SaleProduct(SaleProductRequest request)
        {
            var service = new SaleProductService(_unitOfWork);
            var result = service.Sale(request);
            return Ok(result);
        }
    }
}