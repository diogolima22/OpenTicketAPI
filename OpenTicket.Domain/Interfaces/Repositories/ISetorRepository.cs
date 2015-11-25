using OpenTicket.Domain.Entities;
using System.Collections.Generic;


namespace OpenTicket.Domain.Interfaces.Repositories
{
    public interface ISetorRepository
    {

        List<Setor> List();
        Setor GetById(int id);
        List<Setor> GetNome(string nome);
        void Register(Setor setor);
        void Update(Setor setor);


    }
}
