

using OpenTicket.Domain.Entities;
using System.Collections.Generic;
using OpenTicket.Domain.Commands.SetorCommand;

namespace OpenTicket.Domain.Interfaces.Services
{
    public interface ISetorApplicationService
    {

        List<Setor> List();
        Setor GetId(int id);
        Setor GetNome(string nome);
        Setor Register(Setor setor);
        Setor Update(UpdateSetorCommand command, int id);

    }
}
