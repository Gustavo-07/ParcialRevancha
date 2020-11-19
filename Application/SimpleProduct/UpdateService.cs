using System.ComponentModel.DataAnnotations;
using Dominio.Contracts;
using Dominio.Domain;

namespace Application.SimpleProduct
{
    public class UpdateSimpleProductService
    {
        protected IUnitOfWork UnitOfWork;
        public UpdateSimpleProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public UpdateSimpleResponse UpdatePreparedProduct(UpdatePreparedRequest request)
        {
            var product = UnitOfWork.ProductRepository.Find(request.Id);
            if(product == null) return new UpdateSimpleResponse() { Message = "Este producto no existe."};
            var result = ((Simple) product).InputQuantity(request.Quantity);
            request.Map((Simple) product);
            UnitOfWork.ProductRepository.Edit(product);
            UnitOfWork.Commit();
            return new UpdateSimpleResponse() { Message = result };
        }
        
        public UpdateSimpleResponse UpdateDirectSaleProduct(UpdateDirectSaleRequest request)
        {
            var product = UnitOfWork.ProductRepository.Find(request.Id);
            if(product == null) return new UpdateSimpleResponse() { Message = "Este producto no existe."};
            var result = ((Simple) product).InputQuantity(request.Quantity);
            request.MapDirectSale((Simple) product);
            UnitOfWork.ProductRepository.Edit(product);
            UnitOfWork.Commit();
            return new UpdateSimpleResponse() { Message = result };
        }
        
    }
    
    public class UpdatePreparedRequest
    {
        [Required(ErrorMessage = "El Id es necesario.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "La cantidad del producto es necesario.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "La costo del producto es necesario.")]
        public decimal Cost { get; set; }

        public void Map(Simple simple)
        {
            simple.CostProduct = Cost;
        }
    }
    public class UpdateDirectSaleRequest: UpdatePreparedRequest
    {
        [Required(ErrorMessage = "El precio del producto es necesario.")]
        public decimal Price { get; set; }

        public void MapDirectSale(Simple simple)
        {
            simple.CostProduct = Cost;
            simple.PriceProduct = Price;
        }
    }
    

    public class UpdateSimpleResponse
    {
        public string Message { get; set; }
    }
}