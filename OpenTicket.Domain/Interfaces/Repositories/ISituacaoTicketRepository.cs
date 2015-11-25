using OpenTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTicket.Domain.Interfaces.Repositories
{
    public interface ISituacaoTicketRepository
    {

        List<SituacaoTicket> List();
        List<SituacaoTicket> GetNome(string nome);
        void Register(SituacaoTicket situacaoTicket);
        void Update(SituacaoTicket situacaoTicket);

    }
}
