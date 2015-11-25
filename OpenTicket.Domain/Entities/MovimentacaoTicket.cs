using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTicket.Domain.Entities
{
    public class MovimentacaoTicket
    {

        protected MovimentacaoTicket() { }

        public MovimentacaoTicket(int idTicket, int idUsuario, string resposta, DateTime datacadastro)
        {
            this.IdTicket = idTicket;
            this.IdUsuario = idUsuario;
            this.Resposta = resposta;
            this.DataCadastro = datacadastro;

        }
        [Key]
        public int IdMovimentacao { get; set; }
        public int IdTicket { get; set; }
        public int IdUsuario { get; set; }
        public string Resposta { get; set; }
        public DateTime DataCadastro { get; set; }


        public Usuario Usuario { get; set; }
        public Ticket Ticket { get; set; }



        public void UpdateInfo(int idTicket, int idUsuario, string resposta, DateTime datacadastro)
        {
            this.IdTicket = idTicket;
            this.IdUsuario = idUsuario;
            this.Resposta = resposta;
            this.DataCadastro = datacadastro;

        }
    }
}
