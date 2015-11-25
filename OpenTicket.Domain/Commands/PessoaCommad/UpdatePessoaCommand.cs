using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTicket.Domain.Commands.PessoaCommad
{
    public class UpdatePessoaCommand
    {

        public UpdatePessoaCommand(string nomePessoa, string cpf, DateTime dataNascimento, string email, DateTime dataCadastro)
        {
            this.NomePessoa = nomePessoa;
            this.Cpf = cpf;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.DataCadastro = dataCadastro;

        }
       
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
