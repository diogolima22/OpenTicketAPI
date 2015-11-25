

using OpenTicket.Domain.Entities;
using System.Collections.Generic;
using OpenTicket.Domain.Commands.TicketCommand;

namespace OpenTicket.Domain.Interfaces.Services
{
    public interface ITicketApplicationService
    {

        List<Ticket> List(int idUsuario);
        List<Ticket> GetlAll();
        List<Ticket> Get(int skip, int take);
        Ticket GetId(int id);
        Ticket Register(Ticket ticket);
        Ticket Update(Ticket ticket, int id);
        Ticket UpdateFechamento(UpdateTicketFechamentoCommand command, int id);

    }
}
