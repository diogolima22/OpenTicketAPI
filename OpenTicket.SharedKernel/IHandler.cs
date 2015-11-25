

using OpenTicket.SharedKernel.Events.Contracts;
using System;
using System.Collections.Generic;

namespace OpenTicket.SharedKernel
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {

        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();

    }
}
