using OpenTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTicket.Domain.Commands.FuncionarioCommand;

namespace OpenTicket.Domain.Interfaces.Services
{
    public interface IFuncionarioApplicationService
    {

        List<Funcionario> List();
        List<Funcionario> Get(int skip, int take);
        Funcionario GetId(int id);
        Funcionario GetNome(string nome);
        Funcionario GetCpf(string cpf);
        Funcionario Register(Funcionario funcionario);
        Funcionario Update(UpdateFuncionarioCommad command ,int id);

    }
}
