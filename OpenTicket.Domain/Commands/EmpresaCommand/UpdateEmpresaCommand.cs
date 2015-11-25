using System;

namespace OpenTicket.Domain.Commands.EmpresaCommand
{
    public class UpdateEmpresaCommand
    {


        public UpdateEmpresaCommand(string nomeEmpresa, string cnpj, DateTime datacadastro)
        {
            this.NomeEmpresa = nomeEmpresa;
            this.Cnpj = cnpj;
            this.DataCadastro = datacadastro;

        }
        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
