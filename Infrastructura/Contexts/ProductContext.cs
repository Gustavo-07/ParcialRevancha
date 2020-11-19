using Dominio.Domain;
using Infrastructura.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Contexts
{
    public class ProductContext: DbContextBase
    {
        public ProductContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Simple> Simples { get; set; }
        public DbSet<Compound> Compounds { get; set; }
    }
}