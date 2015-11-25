using OpenTicket.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace OpenTicket.Infra.Persistence.DataContexts
{
    public class StoreDataContext : DbContext
    {

        public StoreDataContext() :
            base("ContextOpenTicket")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<SituacaoTicket> SituacaoTicket { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<MovimentacaoTicket> MovimentacaoTicket { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}