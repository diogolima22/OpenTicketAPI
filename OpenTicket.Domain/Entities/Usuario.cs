using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTicket.SharedKernel.Helpers;

namespace OpenTicket.Domain.Entities
{
 
    public class Usuario
    {

       protected Usuario() { }

        public Usuario(string login, string senha, DateTime dataCadastro, int idEmpresa, int idPessoa, bool isAdmin)
        {
            this.Login = login;
            this.Senha = StringHelper.Encrypt(senha); ;
            this.DataCadastro = dataCadastro;
            this.IdEmpresa = idEmpresa;
            this.IdPessoa = idPessoa;
            this.isAdmin = isAdmin;

        }
        [Key]
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPessoa { get; set; }
        public bool isAdmin { get; set; }


        public Empresa Empresa { get; set; }
        public Pessoa  Pessoa { get; set; }
    }
}
