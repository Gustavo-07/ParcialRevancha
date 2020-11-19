using System;
using Dominio.Repos;

namespace Dominio.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICompoundRepository CompoundRepository { get; }
        int Commit();
    }
}