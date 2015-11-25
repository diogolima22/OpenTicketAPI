

using System;
using System.Collections.Generic;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Persistence.DataContexts;
using System.Linq;

namespace OpenTicket.Infra.Repositories
{
    public class SetorRepository : ISetorRepository
    {
        private StoreDataContext _context;

        public SetorRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public Setor GetById(int id)
        {
            return _context.Setor.Where(x => x.IdSetor == id).FirstOrDefault();
        }

        public List<Setor> GetNome(string nome)
        {
            return _context.Setor.Where(x => x.NomeSetor == nome).ToList();
        }

        public List<Setor> List()
        {
            return _context.Setor.OrderBy(x => x.NomeSetor).ToList();
        }

        public void Register(Setor setor)
        {
            _context.Setor.Add(setor);
        }

        public void Update(Setor setor)
        {
            _context.Entry<Setor>(setor).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
