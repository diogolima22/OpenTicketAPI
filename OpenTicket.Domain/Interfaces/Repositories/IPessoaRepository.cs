using OpenTicket.Domain.Entities;
using System.Collections.Generic;

namespace OpenTicket.Domain.Interfaces.Repositories
{
    public  interface IPessoaRepository
    {

        List<Pessoa> List();
        List<Pessoa> Get(int skip, int take);
        Pessoa GetCpf(string cpf);
        Pessoa GetById(int idPessoa);
        void Register(Pessoa pessoa);
        void Update(Pessoa pessoa);

    }
}
