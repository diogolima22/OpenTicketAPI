

using System;

namespace OpenTicket.Domain.Commands.MovimentacaoTicketCommand
{
    public class UpdateMovimentacaoTicketCommand
    {

        public UpdateMovimentacaoTicketCommand(int idTicket, int idUsuario, string resposta, DateTime datacadastro)
        {
            this.IdTicket = idTicket;
            this.IdUsuario = idUsuario;
            this.Resposta = resposta;
            this.DataCadastro = datacadastro;

        }

        public int IdMovimentacao { get; set; }
        public int IdTicket { get; set; }
        public int IdUsuario { get; set; }
        public string Resposta { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
