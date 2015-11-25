
using System;

namespace OpenTicket.SharedKernel.Events.Contracts
{
    public interface IDomainEvent
    {

        DateTime DateOccurred { get; }

    }
}
