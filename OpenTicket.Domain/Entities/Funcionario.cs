using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace OpenTicket.Domain.Entities
{
    
    public class Funcionario
    {
        protected Funcionario() { }

        public Funcionario(int idPessoa, int idSetor)
        {
            this.IdPessoa = idPessoa;
            this.IdSetor = idSetor;
        }

        [Key]
        public int IdFuncionario { get; set; }
        public int IdPessoa { get; set; }
        public int IdSetor { get; set; }

        public Pessoa Pessoa { get; set; }
        public Setor Setor { get; set; }

        public void UpdateInfo(int idPessoa, int idSetor)
        {

            this.IdPessoa = idPessoa;
            this.IdSetor = idSetor;

        }


    }
}
