using OpenTicket.Domain.Entities;
using System.Collections.Generic;

namespace OpenTicket.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository
    {

        List<Funcionario> List();
        List<Funcionario> Get(int skip, int take);
        Funcionario GetId(int id);
        Funcionario GetCpf(string cpf);
        void Register(Funcionario funcionario);
        void Update(Funcionario funcionario);
        void Delete(Funcionario funcionario);

    }
}
