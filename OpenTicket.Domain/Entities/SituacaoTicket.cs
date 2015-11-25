
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenTicket.Domain.Entities
{

    public class SituacaoTicket
    {
        protected SituacaoTicket() { }
        public SituacaoTicket(string nomeSituacao)
        {
            this.NomeSituacao = nomeSituacao;
        }
        [Key]
        public int IdSituacao { get; set; }
        public string NomeSituacao { get; set; }

    }
}
