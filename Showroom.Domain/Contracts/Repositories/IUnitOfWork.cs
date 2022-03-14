using System;

namespace Showroom.Domain.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}