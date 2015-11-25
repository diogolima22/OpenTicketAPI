using OpenTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTicket.Domain.Commands.PessoaCommad;

namespace OpenTicket.Domain.Interfaces.Services
{
    public interface IPessoaApplicationService
    {

        List<Pessoa> List();
        List<Pessoa> Get(int skip, int take);
        Pessoa GetId(int id);
        Pessoa GetNome(string nome);
        Pessoa GetCpf(string cpf);
        Pessoa Register(Pessoa pessoa);
        Pessoa Update(UpdatePessoaCommand command, int id);

    }
}
