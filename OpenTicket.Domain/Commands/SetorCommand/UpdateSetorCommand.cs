using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTicket.Domain.Commands.SetorCommand
{
    public class UpdateSetorCommand
    {

        public UpdateSetorCommand(string nomeSetor)
        {
            this.NomeSetor = nomeSetor;
        }

 
        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }

    }
}
