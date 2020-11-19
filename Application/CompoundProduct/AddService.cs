using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dominio.Contracts;
using Dominio.Domain;

namespace Application.CompoundProduct
{
    public class AddCompoundProductService
    {
        protected IUnitOfWork UnitOfWork;
        public AddCompoundProductService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public AddCompoundResponse AddCompoundSimpleProduct(AddCompoundRequest request)
        {
            var compound = new Compound();
            request.Minutas.ForEach(delegate(MinutaRequest minutaRequest)
            {
                var product = UnitOfWork.ProductRepository.Find(minutaRequest.IdProduct);
                if (product != null)
                {
                    compound.AddMinuta(product, minutaRequest.Cantidad);
                }
            });
            if (compound.Ingredients.Count == request.Minutas.Count)
            {
                compound.Name = request.Name;
                compound.PriceProduct = request.Price;
                compound.Type = request.Type;
                UnitOfWork.ProductRepository.Add(compound);
                UnitOfWork.Commit();
                return new AddCompoundResponse() { Message = "Producto Compuesto Creado Con exito."};
            }
            else
            {
                return new AddCompoundResponse() { Message = "Los productos y las cantidades no son validas."};
            }
        }
    }

    public class AddCompoundRequest
    {
        [Required(ErrorMessage = "Es necesario el nombre del producto.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Es necesario el precio del producto.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Es necesario el tipo de producto Compuesto.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Es necesario la lista de ingredientes del producto.")]
        public List<MinutaRequest> Minutas { get; set; }
    }

    public class MinutaRequest
    {
        [Required(ErrorMessage = "Se necesita el Id del Producto")]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Se necesita el Cantidad del Producto")]
        public int Cantidad { get; set; }
    }

    public class AddCompoundResponse
    {
        public string Message { get; set; }
    }
}