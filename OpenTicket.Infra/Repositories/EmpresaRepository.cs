using OpenTicket.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using OpenTicket.Domain.Entities;
using OpenTicket.Infra.Persistence.DataContexts;
using System.Linq;

namespace OpenTicket.Infra.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private StoreDataContext _context;

        public EmpresaRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public List<Empresa> Get(int skip, int take)
        {
            return _context.Empresa.OrderBy(x => x.NomeEmpresa).Skip(skip).Take(take).ToList();
        }

        public Empresa GetCnpj(string Cnpj)
        {
            return _context.Empresa.Where(x => x.Cnpj == Cnpj).FirstOrDefault();
      
        }

        public Empresa GetId(int id)
        {
            return _context.Empresa.Where(x => x.IdEmpresa == id).FirstOrDefault();
        }

        public Empresa GetNome(string nome)
        {
            return _context.Empresa.Where(x => x.NomeEmpresa == nome).FirstOrDefault();
        }

        public List<Empresa> List()
        {
            return _context.Empresa.OrderBy(x=> x.NomeEmpresa).ToList();
        }

        public void Register(Empresa empresa)
        {
            _context.Empresa.Add(empresa);
        }
   

        public void Update(Empresa empresa)
        {
            _context.Entry<Empresa>(empresa).State = EntityState.Modified;

        }
    }
}
