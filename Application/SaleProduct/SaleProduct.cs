using System.ComponentModel.DataAnnotations;
using Dominio.Contracts;
using Dominio.Domain;
using Infrastructura.Repos;

namespace Application.SaleProduct
{
    public class SaleProductService
    {
        protected IUnitOfWork UnitOfWork;
        public SaleProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public SaleProductResponse Sale(SaleProductRequest request)
        {
            var product = UnitOfWork.ProductRepository.Find(request.IdProduct);
            if (product.Type == "Prepared") return new SaleProductResponse() { Message = "No se puede vender este producto."};
            var result = "";
            switch(product.Type)
            {
                case "DirectSale": 
                    result = product.TakeProduct(request.Quantity);
                    UnitOfWork.ProductRepository.Edit(product);
                    break;
                case "Sencillo":
                case "Combo":
                    result = product.TakeProduct(request.Quantity);
                    UnitOfWork.CompoundRepository.Edit(product);
                    break;
            }
            UnitOfWork.Commit();
            return new SaleProductResponse() { Message = result};
        }
    }

    public class SaleProductRequest
    {
        [Required(ErrorMessage = "Se necesita el Id del producto a vender")]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Se necesita la cantidad del producto a vender")]
        public int Quantity { get; set; }
    }

    public class SaleProductResponse
    {
        public string Message { get; set; }
    }
}