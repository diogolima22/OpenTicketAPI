namespace OpenTicket.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        IdEmpresa = c.Int(nullable: false, identity: true),
                        NomeEmpresa = c.String(),
                        Cnpj = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        IdFuncionario = c.Int(nullable: false, identity: true),
                        IdPessoa = c.Int(nullable: false),
                        IdSetor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFuncionario)
                .ForeignKey("dbo.Pessoa", t => t.IdPessoa)
                .ForeignKey("dbo.Setor", t => t.IdSetor)
                .Index(t => t.IdPessoa)
                .Index(t => t.IdSetor);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        IdPessoa = c.Int(nullable: false, identity: true),
                        NomePessoa = c.String(),
                        Cpf = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPessoa);
            
            CreateTable(
                "dbo.Setor",
                c => new
                    {
                        IdSetor = c.Int(nullable: false, identity: true),
                        NomeSetor = c.String(),
                    })
                .PrimaryKey(t => t.IdSetor);
            
            CreateTable(
                "dbo.MovimentacaoTicket",
                c => new
                    {
                        IdMovimentacao = c.Int(nullable: false, identity: true),
                        IdTicket = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        Resposta = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdMovimentacao)
                .ForeignKey("dbo.Ticket", t => t.IdTicket)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdTicket)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        IdTicket = c.Int(nullable: false, identity: true),
                        Assunto = c.String(),
                        Prioridade = c.String(),
                        IdEmpresa = c.Int(nullable: false),
                        Descricao = c.String(),
                        IdSituacao = c.Int(nullable: false),
                        IdSetor = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                        DataCdastro = c.DateTime(nullable: false),
                        DataFeichamento = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdTicket)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa)
                .ForeignKey("dbo.Setor", t => t.IdSetor)
                .ForeignKey("dbo.SituacaoTicket", t => t.IdSituacao)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdEmpresa)
                .Index(t => t.IdSituacao)
                .Index(t => t.IdSetor)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.SituacaoTicket",
                c => new
                    {
                        IdSituacao = c.Int(nullable: false, identity: true),
                        NomeSituacao = c.String(),
                    })
                .PrimaryKey(t => t.IdSituacao);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Senha = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        IdEmpresa = c.Int(nullable: false),
                        IdPessoa = c.Int(nullable: false),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa)
                .ForeignKey("dbo.Pessoa", t => t.IdPessoa)
                .Index(t => t.IdEmpresa)
                .Index(t => t.IdPessoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovimentacaoTicket", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.MovimentacaoTicket", "IdTicket", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "IdPessoa", "dbo.Pessoa");
            DropForeignKey("dbo.Usuario", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Ticket", "IdSituacao", "dbo.SituacaoTicket");
            DropForeignKey("dbo.Ticket", "IdSetor", "dbo.Setor");
            DropForeignKey("dbo.Ticket", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Funcionario", "IdSetor", "dbo.Setor");
            DropForeignKey("dbo.Funcionario", "IdPessoa", "dbo.Pessoa");
            DropIndex("dbo.Usuario", new[] { "IdPessoa" });
            DropIndex("dbo.Usuario", new[] { "IdEmpresa" });
            DropIndex("dbo.Ticket", new[] { "IdUsuario" });
            DropIndex("dbo.Ticket", new[] { "IdSetor" });
            DropIndex("dbo.Ticket", new[] { "IdSituacao" });
            DropIndex("dbo.Ticket", new[] { "IdEmpresa" });
            DropIndex("dbo.MovimentacaoTicket", new[] { "IdUsuario" });
            DropIndex("dbo.MovimentacaoTicket", new[] { "IdTicket" });
            DropIndex("dbo.Funcionario", new[] { "IdSetor" });
            DropIndex("dbo.Funcionario", new[] { "IdPessoa" });
            DropTable("dbo.Usuario");
            DropTable("dbo.SituacaoTicket");
            DropTable("dbo.Ticket");
            DropTable("dbo.MovimentacaoTicket");
            DropTable("dbo.Setor");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Empresa");
        }
    }
}
