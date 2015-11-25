
using OpenTicket.Domain.Entities;
using OpenTicket.SharedKernel.Helpers;
using System;
using System.Linq.Expressions;

namespace OpenTicket.Domain.Specs
{
    public class UsuarioSpecs
    {

        public static Expression<Func<Usuario, bool>> AuthenticateUser(string email, string password)
        {
            string encriptedPassword = StringHelper.Encrypt(password);
            return x => x.Login == email && x.Senha == encriptedPassword;
        }

        public static Expression<Func<Usuario, bool>> GetByEmail(string email)
        {
            return x => x.Login == email;
        }


    }
}
