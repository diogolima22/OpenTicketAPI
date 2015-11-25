using OpenTicket.Domain.Entities;
using System.Collections.Generic;
using OpenTicket.Domain.Commands.EmpresaCommand;

namespace OpenTicket.Domain.Interfaces.Services
{
    public interface IEmpresaApplicationService
    {

        List<Empresa> List();
        List<Empresa> Get(int skip, int take);
        Empresa GetId(int id);
        Empresa GetNome(string nome);
        Empresa GetCnpj(string Cnpj);
        Empresa Register(Empresa empresa);
        Empresa Update(UpdateEmpresaCommand command, int id);

    }
}
