using System;

namespace OpenTicket.Infra.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        void Commit();

    }
}
