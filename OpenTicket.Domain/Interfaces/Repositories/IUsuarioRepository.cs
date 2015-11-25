

using OpenTicket.Domain.Entities;
using System.Collections.Generic;

namespace OpenTicket.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {

        void Register(Usuario usuario);
        Usuario Authenticate(string email, string password);
        Usuario GetByEmail(string email);
        List<Usuario> List();

    }
}
