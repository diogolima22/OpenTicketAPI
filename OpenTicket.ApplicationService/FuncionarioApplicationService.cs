using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTicket.Domain.Commands.FuncionarioCommand;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Repositories;
using OpenTicket.Infra.Persistence;

namespace OpenTicket.ApplicationService
{
    public class FuncionarioApplicationService : ApplicationService, IFuncionarioApplicationService
    {
        private IFuncionarioRepository _repository;

        public FuncionarioApplicationService(FuncionarioRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<Funcionario> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Funcionario GetCpf(string cpf)
        {
            return _repository.GetCpf(cpf);
        }

        public Funcionario GetId(int id)
        {
            return _repository.GetId(id);
        }

        public Funcionario GetNome(string nome)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> List()
        {
            return _repository.List();
        }

        public Funcionario Register(Funcionario funcionario)
        {
            var _funcionario = new Funcionario(funcionario.IdPessoa,funcionario.IdSetor);


            _repository.Register(_funcionario);

            if (Commit())
                return _funcionario;

            return null;
        }

        public Funcionario Update(UpdateFuncionarioCommad command, int id)
        {
            var _funcionario = _repository.GetId(id);
            _funcionario.UpdateInfo(command.IdPessoa,command.IdSetor);
            _repository.Update(_funcionario);

            if (Commit())
                return _funcionario;

            return null;
        }
    }
}
