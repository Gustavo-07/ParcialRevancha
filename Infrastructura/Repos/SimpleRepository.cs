using Dominio.Domain;
using Dominio.Repos;
using Infrastructura.Base;

namespace Infrastructura.Repos
{
    public class SimpleRepository: GenericRepository<Simple>, ISimpleRepository
    {
        public SimpleRepository(IDbContext context) : base(context)
        {
        }
    }
}