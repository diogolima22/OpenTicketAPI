using System.Collections.Generic;
using OpenTicket.Domain.Commands.MovimentacaoTicketCommand;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Domain.Interfaces.Services;
using OpenTicket.Infra.Persistence;
using OpenTicket.Infra.Repositories;

namespace OpenTicket.ApplicationService
{
    public class MovimentacaoTicketApplicationService : ApplicationService, IMovimentacaoTicketApplicationService
    {
        private IMovimentacaoTicketRepository _repository;

        public MovimentacaoTicketApplicationService(MovimentacaoTicketRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public List<MovimentacaoTicket> GetByIdTicket(int idTicket)
        {
            return _repository.GetByIdTicket(idTicket);
        }

        public MovimentacaoTicket Register(MovimentacaoTicket movimentacao)
        {
            var _movimentacao = new MovimentacaoTicket(movimentacao.IdTicket, movimentacao.IdUsuario,movimentacao.Resposta,
                                                       movimentacao.DataCadastro);


            _repository.Register(_movimentacao);

            if (Commit())
                return _movimentacao;

            return null;
        }

        public MovimentacaoTicket Update(UpdateMovimentacaoTicketCommand command,int id)
        {
            var _movimentacao = _repository.GrtById(id);
            _movimentacao.UpdateInfo(command.IdTicket, command.IdUsuario,command.Resposta,command.DataCadastro);
            _repository.Update(_movimentacao);

            if (Commit())
                return _movimentacao;

            return null;
        }
    }
}
