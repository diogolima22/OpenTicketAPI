using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenTicket.Domain.Entities
{

    public class Empresa
    {
        protected Empresa(){}

        public Empresa(string nomeEmpresa, string cnpj, DateTime datacadastro)
        {
            this.NomeEmpresa = nomeEmpresa;
            this.Cnpj = cnpj;
            this.DataCadastro = datacadastro;

        }
        [Key]
        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataCadastro { get; set; }

        public void UpdateInfo(string nomeEmpresa, string cnpj, DateTime datacadastro)
        {
            this.NomeEmpresa = nomeEmpresa;
            this.Cnpj = cnpj;
            this.DataCadastro = datacadastro;
        }
    }

}
