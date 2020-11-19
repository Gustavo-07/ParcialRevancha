using System.Collections.Generic;
using Dominio.Domain;
using Dominio.Repos;
using Infrastructura.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Repos
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IDbContext context) : base(context)
        {
        }
    }
}