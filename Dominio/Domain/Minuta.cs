using Dominio.Base;

namespace Dominio.Domain
{
    public class Minuta: Entity<int>
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Minuta()
        {
        }
    }
}