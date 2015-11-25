

using OpenTicket.Domain.Entities;
using System.Collections.Generic;

namespace OpenTicket.Domain.Interfaces.Services
{
    public interface ISituacaoTicketApplicationService
    {

        List<SituacaoTicket> List();
        SituacaoTicket GetNome(string nome);
        SituacaoTicket Register(SituacaoTicket situacao);
        SituacaoTicket Update(SituacaoTicket situacao);

    }
}
