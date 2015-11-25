using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTicket.Domain.Commands.TicketCommand
{
    public class UpdateTicketFechamentoCommand
    {

        public UpdateTicketFechamentoCommand(DateTime dataFechamento, int idSituacao)
        {

            this.DataFeichamento = dataFechamento;
            this.IdSituacao = idSituacao;

        }
    
        public int IdTicket { get; set; }
        public string Assunto { get; set; }
        public string Prioridade { get; set; }
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
        public int IdSituacao { get; set; }
        public int IdSetor { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataCdastro { get; set; }
        public DateTime DataFeichamento { get; set; }

    }
}
