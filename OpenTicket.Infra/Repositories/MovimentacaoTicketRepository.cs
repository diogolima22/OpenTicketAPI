using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Persistence.DataContexts;

namespace OpenTicket.Infra.Repositories
{
    public class MovimentacaoTicketRepository : IMovimentacaoTicketRepository
    {
        private StoreDataContext _context;

        public MovimentacaoTicketRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public List<MovimentacaoTicket> GetByIdTicket(int idTicket)
        {
            return _context.MovimentacaoTicket.Where(x => x.IdTicket == idTicket).ToList();
        }

        public MovimentacaoTicket GrtById(int id)
        {
            return _context.MovimentacaoTicket.Where(x => x.IdMovimentacao == id).FirstOrDefault();
        }

        public void Register(MovimentacaoTicket movimentacao)
        {
            _context.MovimentacaoTicket.Add(movimentacao);
        }

        public void Update(MovimentacaoTicket movimentacao)
        {
            _context.Entry<MovimentacaoTicket>(movimentacao).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
