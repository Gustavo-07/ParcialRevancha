using Application.SimpleProduct;
using Dominio.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductSimpleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductSimpleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        [Route("Prepared")]
        public ActionResult<AddSimpleResponse> AddProductPrepared(AddSimpleRequest request)
        {
            var service = new AddSimpleProductService(_unitOfWork);
            var response = service.AddPrepared(request);
            return Ok(response);
        }
        
        [HttpPost]
        [Route("AddDirectSale")]
        public ActionResult<AddSimpleResponse> AddProductDirectSale(AddDirectSaleRequest request)
        {
            var service = new AddSimpleProductService(_unitOfWork);
            var response = service.AddDirectSale(request);
            return Ok(response);
        }
        
        [HttpPut]
        [Route("Salida Producto Simple")]
        public ActionResult<UpdateSimpleResponse> InputSimple(InputRequest request)
        {
            var service = new InputService(_unitOfWork);
            var response = service.Ejecutar(request);
            return Ok(response); 
        }

        [HttpPut]
        [Route("Prepared")]
        public ActionResult<UpdateSimpleResponse> UpdateProductSimple(UpdatePreparedRequest request)
        {
            var service = new UpdateSimpleProductService(_unitOfWork);
            var response = service.UpdatePreparedProduct(request);
            return Ok(response); 
        }
        
        [HttpPut]
        [Route("DirectSale")]
        public ActionResult<UpdateSimpleResponse> UpdateProductSimpleDirectSale(UpdateDirectSaleRequest request)
        {
            var service = new UpdateSimpleProductService(_unitOfWork);
            var response = service.UpdateDirectSaleProduct(request);
            return Ok(response); 
        }
    }
}