

using System;
using System.Collections.Generic;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Persistence.DataContexts;
using System.Linq;

namespace OpenTicket.Infra.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private StoreDataContext _context;

        public FuncionarioRepository(StoreDataContext context)
        {
            this._context = context;
        }
        public void Delete(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> Get(int skip, int take)
        {
            return _context.Funcionario.OrderBy(x => x.Pessoa.NomePessoa).Skip(skip).Take(take).ToList();
        }

        public Funcionario GetCpf(string cpf)
        {
            return _context.Funcionario.Where(x => x.Pessoa.Cpf == cpf).FirstOrDefault();
        }

        public Funcionario GetId(int id)
        {
            return _context.Funcionario.Where(x => x.IdFuncionario == id).FirstOrDefault();
        }

        public List<Funcionario> List()
        {
            return _context.Funcionario.OrderBy(x => x.Pessoa.NomePessoa).ToList();
        }

        public void Register(Funcionario funcionario)
        {
            _context.Funcionario.Add(funcionario);
        }

        public void Update(Funcionario funcionario)
        {
            _context.Entry<Funcionario>(funcionario).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
