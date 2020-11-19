using System.ComponentModel.DataAnnotations;
using Dominio.Contracts;
using Dominio.Domain;

namespace Application.SimpleProduct
{
    public class AddSimpleProductService
    {
        protected IUnitOfWork UnitOfWork;
        public AddSimpleProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public AddSimpleResponse AddPrepared(AddSimpleRequest request)
        {
            var simple = request.MapPrepared();
            var result = simple.InputQuantity(request.Quantity);
            UnitOfWork.ProductRepository.Add(simple);
            UnitOfWork.Commit();
            return new AddSimpleResponse() { Message = result };
        }
        
        public AddSimpleResponse AddDirectSale(AddDirectSaleRequest request)
        {
            var simple = request.MapDirectSale();
            var result = simple.InputQuantity(request.Quantity);
            UnitOfWork.ProductRepository.Add(simple);
            UnitOfWork.Commit();
            return new AddSimpleResponse() { Message = result };
        }
    }

    public class AddSimpleRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Simple MapPrepared()
        {
            return new Simple() { Name = Name, CostProduct = Cost, Type = "Prepared"};
        }
    }

    public class AddDirectSaleRequest : AddSimpleRequest
    {
        [Required]
        public decimal Price { get; set; }

        public Simple MapDirectSale()
        {
            return new Simple() { Name = Name, CostProduct = Cost, Type = "DirectSale", PriceProduct = Price };
        }
    }

    public class AddSimpleResponse
    {
        public string Message { get; set; }
    }
}