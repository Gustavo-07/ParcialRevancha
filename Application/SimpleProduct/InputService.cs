using Dominio.Contracts;

namespace Application.SimpleProduct
{
    public class InputService
    {

        readonly IUnitOfWork _unitOfWork;
        
        public InputService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public InputResponse Ejecutar(InputRequest request)
        {
            var Simple= _unitOfWork.SimpleRepository.FindFirstOrDefault(t => t.Id==request.Id);
            if (Simple != null)
            {
                Simple.InputQuantity(request.Cantidad);
                _unitOfWork.Commit();
                return new InputResponse() { Mensaje = $"Su cantidad es {Simple.Quantity}." };
            }
            else
            {
                return new InputResponse() { Mensaje = $"Producto No Válido." };
            }
        }
    }
    
    public class InputRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }
    public class InputResponse
    {
        public string Mensaje { get; set; }
    }
}