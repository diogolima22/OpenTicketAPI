using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Repositories;
using OpenTicket.Infra.Persistence;
using OpenTicket.Domain.Commands.PessoaCommad;

namespace OpenTicket.ApplicationService
{
    public class PessoaApplicationService : ApplicationService, IPessoaApplicationService
    {
        private IPessoaRepository _repository;

        public PessoaApplicationService(PessoaRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<Pessoa> Get(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Pessoa GetCpf(string cpf)
        {
            return _repository.GetCpf(cpf);
        }

        public Pessoa GetId(int id)
        {
            return _repository.GetById(id);
        }

        public Pessoa GetNome(string nome)
        {
            throw new NotImplementedException();
        }

        public List<Pessoa> List()
        {
            return _repository.List();
        }

        public Pessoa Register(Pessoa pessoa)
        {
            var _pessoa = new Pessoa(pessoa.NomePessoa,pessoa.Cpf,pessoa.DataNascimento,pessoa.Email, pessoa.DataCadastro);


            _repository.Register(_pessoa);

            if (Commit()) 
                return _pessoa;

            return null;
        }

        public Pessoa Update(UpdatePessoaCommand command, int id)
        {
            var _pessoa = _repository.GetById(id);
            _pessoa.UpdateInfo(command.NomePessoa, command.Cpf, command.DataNascimento, command.Email, command.DataCadastro);
            _repository.Update(_pessoa);

            if (Commit())
                return _pessoa;

            return null;
        }
    }
}
