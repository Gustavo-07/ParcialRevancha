using System.ComponentModel.DataAnnotations;
using Dominio.Contracts;
using Dominio.Domain;
using Infrastructura.Repos;

namespace Application.SaleProduct
{
    public class AddProductService
    {
        protected IUnitOfWork UnitOfWork;
        public AddProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public AddProductResponse Sale(AddProductRequest request)
        {
            var product = UnitOfWork.ProductRepository.Find(request.IdProduct);
            if (product.Type == "Prepared") return new AddProductResponse() { Message = "No se puede vender este producto."};
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
                    UnitOfWork.ProductRepository.Edit(product);
                    break;
            }
            UnitOfWork.Commit();
            return new AddProductResponse() { Message = result};
        }
    }

    public class AddProductRequest
    {
        [Required(ErrorMessage = "Se necesita el Id del producto a vender")]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Se necesita la cantidad del producto a vender")]
        public int Quantity { get; set; }
    }

    public class AddProductResponse
    {
        public string Message { get; set; }
    }
}