using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Contracts;
using Dominio.Domain;

namespace Application.CompoundProduct
{
    public class UpdateCompoundService
    {
        protected IUnitOfWork UnitOfWork;
        public UpdateCompoundService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public UpdateCompoundResponse UpdateCompound(UpdateCompoundRequest request)
        {
            var producto = UnitOfWork.ProductRepository.Find(request.Id);
            if(producto == null) return new UpdateCompoundResponse() { Message = "Producto no encontrado."};
            producto.PriceProduct = request.Price;
            UnitOfWork.ProductRepository.Edit(producto);
            UnitOfWork.Commit();
            return new UpdateCompoundResponse() { Message = "Producto Actualizado"};
        }
    }
    
    public class UpdateCompoundRequest
    {
        [Required(ErrorMessage = "Es necesario el nombre del producto.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Es necesario el precio del producto.")]
        public decimal Price { get; set; }
    }
    

    public class UpdateCompoundResponse
    {
        public string Message { get; set; }
    }
}