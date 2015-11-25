

using System;
using System.Collections.Generic;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Persistence.DataContexts;
using System.Linq;

namespace OpenTicket.Infra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private StoreDataContext _context;

        public PessoaRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public List<Pessoa> Get(int skip, int take)
        {
            return _context.Pessoa.OrderBy(x => x.NomePessoa).Skip(skip).Take(take).ToList();
        }

        public Pessoa GetById(int idPessoa)
        {
            return _context.Pessoa.Where(x => x.IdPessoa == idPessoa).FirstOrDefault();
           
        }

        public Pessoa GetCpf(string cpf)
        {
            return _context.Pessoa.Where(x => x.Cpf == cpf).FirstOrDefault();
        }

        public List<Pessoa> List()
        {
            return _context.Pessoa.OrderBy(x => x.NomePessoa).ToList();
        }

        public void Register(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
        }

        public void Update(Pessoa pessoa)
        {
            _context.Entry<Pessoa>(pessoa).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
