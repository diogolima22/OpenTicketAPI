using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTicket.Domain.Commands.FuncionarioCommand
{
    public class UpdateFuncionarioCommad
    {


        public UpdateFuncionarioCommad(int idPessoa, int idSetor)
        {
            this.IdPessoa = idPessoa;
            this.IdSetor = idSetor;
        }

    
        public int IdFuncionario { get; set; }
        public int IdPessoa { get; set; }
        public int IdSetor { get; set; }

   

    }
}
