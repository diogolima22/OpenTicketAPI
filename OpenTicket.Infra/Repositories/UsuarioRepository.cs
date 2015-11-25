
using System.Collections.Generic;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Persistence.DataContexts;
using System.Linq;
using OpenTicket.Domain.Specs;

namespace OpenTicket.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private StoreDataContext _context;

        public UsuarioRepository(StoreDataContext context)
        {
            this._context = context;
        }

        public Usuario Authenticate(string email, string password)
        {
            return _context.Usuario
                 .Where(UsuarioSpecs.AuthenticateUser(email, password))
                 .FirstOrDefault();
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuario
                .Where(UsuarioSpecs.GetByEmail(email))
                .FirstOrDefault();
        }

        public List<Usuario> List()
        {
            return _context.Usuario.OrderBy(x => x.Login ).ToList();
        }

        public void Register(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
        }

    }
}