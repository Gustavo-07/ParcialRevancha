using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Domain;
using Dominio.Repos;
using Infrastructura.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Repos
{
    public class CompoundRepository: GenericRepository<Compound>, ICompoundRepository
    {
        public CompoundRepository(IDbContext context) : base(context)
        {
        }

        
    }
}