using OpenTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTicket.Domain.Interfaces.Repositories
{
    public interface ITicketRepository
    {

        List<Ticket> List(int idUsuario);
        List<Ticket> GetAll();
        List<Ticket> Get(int skip, int take);
        Ticket GetId(int id);
        Ticket GetNome(string nome);
        void Register(Ticket ticket);
        void Update(Ticket ticket);

    }
}
