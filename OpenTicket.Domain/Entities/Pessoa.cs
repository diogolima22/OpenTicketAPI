using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenTicket.Domain.Entities
{
    public class Pessoa
    {
        protected Pessoa() { }
        public Pessoa(string nomePessoa, string cpf, DateTime dataNascimento,string email,DateTime dataCadastro)
        {
            this.NomePessoa = nomePessoa;
            this.Cpf = cpf;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.DataCadastro = dataCadastro;

        }
        [Key]
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }

        public void UpdateInfo(string nomePessoa, string cpf, DateTime dataNascimento, string email,
            DateTime dataCadastro)
        {

            this.NomePessoa = nomePessoa;
            this.Cpf = cpf;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.DataCadastro = dataCadastro;

        }

    }
}
