using Dominio.Contracts;
using Dominio.Repos;
using Infrastructura.Repos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructura.Base
{
    public class UnitOfWork: IUnitOfWork
    {
        private IDbContext _dbContext;
        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get { return _productRepository ??= new ProductRepository(_dbContext); }
        }

        private ICompoundRepository _compoundRepository;
        public ICompoundRepository CompoundRepository
        {
            get { return _compoundRepository ??= new CompoundRepository(_dbContext); }
        }

        public UnitOfWork(IDbContext context)
        {
            _dbContext = context;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null) return;
            ((DbContext)_dbContext).Dispose();
            _dbContext = null;
        }
    }
}