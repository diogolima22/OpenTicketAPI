using OpenTicket.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTicket.Domain.Entities;
using OpenTicket.Infra.Persistence.DataContexts;

namespace OpenTicket.Infra.Repositories
{
    public class SituacaoTicketRepository : ISituacaoTicketRepository
    {
        private StoreDataContext _context;

        public SituacaoTicketRepository(StoreDataContext context)
        {
            this._context = context;
        }


        public List<SituacaoTicket> GetNome(string nome)
        {
            return _context.SituacaoTicket.Where(x => x.NomeSituacao == nome).ToList();
        }

        public List<SituacaoTicket> List()
        {
            return _context.SituacaoTicket.OrderBy(x => x.NomeSituacao).ToList();
        }

        public void Register(SituacaoTicket situacaoTicket)
        {
            _context.SituacaoTicket.Add(situacaoTicket);
        }

        public void Update(SituacaoTicket situacaoTicket)
        {
            _context.Entry<SituacaoTicket>(situacaoTicket).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
