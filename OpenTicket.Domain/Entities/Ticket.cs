using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace OpenTicket.Domain.Entities
{

    public class Ticket
    {
        protected Ticket() { }
        public Ticket(string assunto, string prioridade,int idempresa,string descricao, 
                      int idSituacao,  int idSetor, int idUsuario, DateTime dataCadastro
                      )  
        {
            this.Assunto = assunto;
            this.Prioridade = prioridade;
            this.IdEmpresa = idempresa;
            this.Descricao = descricao;
            this.IdSituacao = idSituacao;
            this.IdSetor = idSetor;
            this.IdUsuario = idUsuario;
            this.DataCdastro = dataCadastro;

        }
        [Key]
        public int IdTicket { get; set; }
        public string Assunto { get; set; }
        public string  Prioridade { get; set; }
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
        public int IdSituacao { get; set; }
        public int IdSetor { get; set; }
        public int IdUsuario { get; set; }
        public DateTime DataCdastro { get; set; }
        public  DateTime? DataFeichamento { get; set; }


        public  Empresa empresa { get; set; }
        public  SituacaoTicket SituacaoTicket { get; set; }     
        public  Setor Setor { get; set; }
        public  Usuario Usuario { get; set; }


        public void UpdateInfo(string assunto, string prioridade, int idempresa, string descricao,
                      int idSituacao, int idSetor, int idUsuario, DateTime dataCadastro
                      )
        {

            {
                this.Assunto = assunto;
                this.Prioridade = prioridade;
                this.IdEmpresa = idempresa;
                this.Descricao = descricao;
                this.IdSituacao = idSituacao;
                this.IdSetor = idSetor;
                this.IdUsuario = idUsuario;
                this.DataCdastro = dataCadastro;

            }

        }

        public void UpdateDataFechamento(DateTime dataFechamento, int idSituacao)
        {
            this.DataFeichamento = dataFechamento;
            this.IdSituacao = idSituacao;
        }


    }
}
