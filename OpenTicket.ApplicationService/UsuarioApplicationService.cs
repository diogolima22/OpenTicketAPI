using OpenTicket.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenTicket.Domain.Entities;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Infra.Persistence;

namespace OpenTicket.ApplicationService
{
    public class UsuarioApplicationService : ApplicationService, IUsuarioApplicationService
    {
        private IUsuarioRepository _repository;

        public UsuarioApplicationService(IUsuarioRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }


        public Usuario Authenticate(string email, string password)
        {
            return _repository.Authenticate(email, password);
        }

        public List<Usuario> List()
        {
            return _repository.List();
        }

        public Usuario Register(Usuario usuario)
        {
            var _usuario = new Usuario(usuario.Login, usuario.Senha , usuario.DataCadastro, usuario.IdEmpresa, usuario.IdPessoa, usuario.isAdmin);
            _repository.Register(usuario);

            if (Commit())
                return usuario;

            return null;
        }
    }
}
