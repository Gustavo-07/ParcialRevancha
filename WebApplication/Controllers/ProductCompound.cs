using Application.CompoundProduct;
using Dominio.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCompoundController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCompoundController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public ActionResult<AddCompoundResponse> AddProductCompound(AddCompoundRequest request)
        {
            var service = new AddCompoundProductService(_unitOfWork);
            var response = service.AddCompoundSimpleProduct(request);
            return Ok(response);
        }
        
        [HttpPut]
        public ActionResult<UpdateCompoundResponse> UpdateProductCompound(UpdateCompoundRequest request)
        {
            var service = new UpdateCompoundService(_unitOfWork);
            var response = service.UpdateCompound(request);
            return Ok(response);
        }
    }
}