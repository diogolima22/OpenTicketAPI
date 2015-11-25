

using System.Collections.Generic;
using OpenTicket.Domain.Commands.MovimentacaoTicketCommand;
using OpenTicket.Domain.Entities;

namespace OpenTicket.Domain.Interfaces.Services
{
     public interface  IMovimentacaoTicketApplicationService
    {

         MovimentacaoTicket Register(MovimentacaoTicket movimentacao);
         List<MovimentacaoTicket> GetByIdTicket(int idTicket);
         MovimentacaoTicket Update(UpdateMovimentacaoTicketCommand command, int id);

    }
}
