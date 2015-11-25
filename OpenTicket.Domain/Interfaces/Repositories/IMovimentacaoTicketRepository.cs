
using System.Collections.Generic;
using OpenTicket.Domain.Entities;

namespace OpenTicket.Domain.Interfaces.Repositories
{
    public interface IMovimentacaoTicketRepository
    {

        void Register(MovimentacaoTicket movimentacao);
        List<MovimentacaoTicket> GetByIdTicket(int idTicket);
        MovimentacaoTicket GrtById(int id);
        void Update(MovimentacaoTicket movimentacao);

    }
}
