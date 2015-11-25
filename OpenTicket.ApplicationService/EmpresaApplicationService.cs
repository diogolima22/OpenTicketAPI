using System;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Domain.Interfaces.Services;
using OpenTicket.Infra.Repositories;
using System.Collections.Generic;
using OpenTicket.Domain.Commands.EmpresaCommand;
using OpenTicket.Domain.Entities;
using OpenTicket.Infra.Persistence;

namespace OpenTicket.ApplicationService
{
   public  class EmpresaApplicationService : ApplicationService, IEmpresaApplicationService
    {
        private IEmpresaRepository _repository;

        public EmpresaApplicationService(EmpresaRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<Empresa> Get(int skip, int take)
        {
            return _repository.Get(skip, take);
        }

        public Empresa GetCnpj(string Cnpj)
        {
            return _repository.GetCnpj(Cnpj);
        }

        public Empresa GetId(int id)
        {
            return _repository.GetId(id);
        }

        public Empresa GetNome(string nome)
        {
            return _repository.GetNome(nome);
        }

        public List<Empresa> List()
        {
            return _repository.List();
        }

        public Empresa Register(Empresa empresa)
        {
            var _empresa = new Empresa(empresa.NomeEmpresa, empresa.Cnpj,empresa.DataCadastro);

            
            _repository.Register(_empresa);

            if (Commit())
                return _empresa;

            return null;
        }

        public Empresa Update(UpdateEmpresaCommand command,int id)
        {
            var _empresa = _repository.GetId(id);
            _empresa.UpdateInfo(command.NomeEmpresa,command.Cnpj,command.DataCadastro);
               _repository.Update(_empresa);

            if (Commit())
                return _empresa;

            return null;
        }
    }
}
