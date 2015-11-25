using OpenTicket.Domain.Entities;
using System.Collections.Generic;
using OpenTicket.Domain.Commands.EmpresaCommand;

namespace OpenTicket.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository
    {

        List<Empresa> List();
        List<Empresa> Get(int skip, int take);
        Empresa GetId(int id);
        Empresa GetNome(string nome);
        Empresa GetCnpj(string Cnpj);
        void Register(Empresa empresa);
        void Update(Empresa empresa);

    }
}
