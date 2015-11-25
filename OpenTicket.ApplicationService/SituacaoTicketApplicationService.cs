

using System;
using System.Collections.Generic;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Services;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Repositories;
using OpenTicket.Infra.Persistence;

namespace OpenTicket.ApplicationService
{
    public class SituacaoTicketApplicationService : ApplicationService, ISituacaoTicketApplicationService
    {
        private ISituacaoTicketRepository _repository;

        public SituacaoTicketApplicationService(SituacaoTicketRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }


        public SituacaoTicket GetNome(string nome)
        {
            throw new NotImplementedException();
        }

        public List<SituacaoTicket> List()
        {
            return _repository.List();
        }

        public SituacaoTicket Register(SituacaoTicket situacao)
        {
            var _situacaoTicket = new SituacaoTicket(situacao.NomeSituacao);


            _repository.Register(_situacaoTicket);

            if (Commit())
                return _situacaoTicket;

            return null;
        }

        public SituacaoTicket Update(SituacaoTicket situacao)
        {
            throw new NotImplementedException();
        }
    }
}
