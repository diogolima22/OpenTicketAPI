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
    public class TicketRepository : ITicketRepository
    {

        private StoreDataContext _context;

        public TicketRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public List<Ticket> Get(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetAll()
        {
            return _context.Ticket.OrderBy(x => x.IdTicket).ToList();
        }

        public Ticket GetId(int id)
        {
            return _context.Ticket.Where(x => x.IdTicket == id).FirstOrDefault();
        }

        public Ticket GetNome(string nome)
        {
            return _context.Ticket.Where(x => x.Assunto == nome).FirstOrDefault();
        }

        public List<Ticket> List(int idUsuario)
        {
            return _context.Ticket.Where(x => x.IdUsuario == idUsuario).ToList();
        }

        public void Register(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            _context.Entry<Ticket>(ticket).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
