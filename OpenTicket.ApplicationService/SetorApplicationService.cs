using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTicket.Domain.Commands.SetorCommand;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Repositories;
using OpenTicket.Infra.Persistence;

namespace OpenTicket.ApplicationService
{
    public class SetorApplicationService : ApplicationService, ISetorApplicationService
    {
        private ISetorRepository _repository;

        public SetorApplicationService(SetorRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public Setor GetId(int id)
        {
            return _repository.GetById(id);

        }

        public Setor GetNome(string nome)
        {
            throw new NotImplementedException();
        }

        public List<Setor> List()
        {
            return _repository.List();
        }

        public Setor Register(Setor setor)
        {
            var _setor = new Setor(setor.NomeSetor);


            _repository.Register(_setor);

            if (Commit())
                return _setor;

            return null;
        }


        public Setor Update(UpdateSetorCommand command, int id)
        {
            var _setor = _repository.GetById(id);
            _setor.UpdateInfo(command.NomeSetor);
            _repository.Update(_setor);

            if (Commit())
                return _setor;

            return null;
        }
    }
}
