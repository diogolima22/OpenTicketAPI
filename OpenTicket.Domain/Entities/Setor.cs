using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTicket.Domain.Entities
{
 
    public class Setor
    {
        protected Setor() { }
        public Setor(string nomeSetor)
        {
            this.NomeSetor = nomeSetor;
        }

        [Key]
        public int IdSetor { get; set; }
        public string  NomeSetor { get; set; }


        public void UpdateInfo(string nomeSetor)
        {

            this.NomeSetor = nomeSetor;

        }


    }
}
