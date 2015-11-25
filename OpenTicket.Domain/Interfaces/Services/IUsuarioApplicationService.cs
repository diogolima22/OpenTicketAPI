

using OpenTicket.Domain.Entities;
using System.Collections.Generic;

namespace OpenTicket.Domain.Interfaces.Services
{
    public interface IUsuarioApplicationService
    {

        Usuario Register(Usuario usuario);
        Usuario Authenticate(string email, string password);
        List<Usuario> List();

    }
}
