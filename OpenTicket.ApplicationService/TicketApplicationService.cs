using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTicket.Domain.Entities;
using OpenTicket.Infra.Repositories;
using OpenTicket.Infra.Persistence;
using OpenTicket.Domain.Commands.TicketCommand;

namespace OpenTicket.ApplicationService
{
    public class TicketApplicationService : ApplicationService, ITicketApplicationService
    {

        private TicketRepository _repository;

        public TicketApplicationService(TicketRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }


        public List<Ticket> Get(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Ticket GetId(int id)
        {
            return _repository.GetId(id);
        }

        public List<Ticket> GetlAll()
        {
            return _repository.GetAll();
        }

        public List<Ticket> List(int idUsuario)
        {
            return _repository.List(idUsuario);
        }

        public Ticket Register(Ticket ticket)
        {
            var _ticket = new Ticket(ticket.Assunto,ticket.Prioridade,ticket.IdEmpresa,ticket.Descricao,
                                     ticket.IdSituacao,ticket.IdSetor, ticket.IdUsuario,ticket.DataCdastro);


            _repository.Register(_ticket);

            if (Commit())
                return _ticket;

            return null;
        }

        public Ticket Update(Ticket ticket, int id)
        {
            var _ticket = _repository.GetId(id);
            _ticket.UpdateInfo(ticket.Assunto,ticket.Prioridade,ticket.IdEmpresa,ticket.Descricao,ticket.IdSituacao,ticket.IdSetor,ticket.IdUsuario,ticket.DataCdastro);
            _repository.Update(_ticket);

            if (Commit())
                return _ticket;

            return null;
        }

        public Ticket UpdateFechamento(UpdateTicketFechamentoCommand command, int id)
        {
            var _ticket = _repository.GetId(id);
            _ticket.UpdateDataFechamento(command.DataFeichamento,command.IdSituacao);
            _repository.Update(_ticket);

            if (Commit())
                return _ticket;

            return null;
        }
    }
}
