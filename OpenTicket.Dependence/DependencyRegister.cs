using Microsoft.Practices.Unity;
using OpenTicket.ApplicationService;
using OpenTicket.Domain.Interfaces.Repositories;
using OpenTicket.Domain.Interfaces.Services;
using OpenTicket.Infra.Persistence;
using OpenTicket.Infra.Persistence.DataContexts;
using OpenTicket.Infra.Repositories;
using OpenTicket.SharedKernel;
using OpenTicket.SharedKernel.Events;

namespace OpenTicket.Dependence
{
    public static class DependencyRegister
    {
        /// <summary>
        /// TransientLifetimeManager - Cada Resolve gera uma nova instância.
        /// HierarchicalLifetimeManager - Utiliza Singleton
        /// </summary>
        /// <param name="container"></param>

        public static void Register(UnityContainer container)
        {
            container.RegisterType<StoreDataContext, StoreDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaRepository, PessoaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFuncionarioRepository, FuncionarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmpresaRepository, EmpresaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISetorRepository, SetorRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISituacaoTicketRepository, SituacaoTicketRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITicketRepository, TicketRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMovimentacaoTicketRepository, MovimentacaoTicketRepository>(new HierarchicalLifetimeManager());




            container.RegisterType<IUsuarioApplicationService, UsuarioApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPessoaApplicationService, PessoaApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFuncionarioApplicationService, FuncionarioApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmpresaApplicationService, EmpresaApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISetorApplicationService, SetorApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISituacaoTicketApplicationService, SituacaoTicketApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITicketApplicationService, TicketApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMovimentacaoTicketApplicationService, MovimentacaoTicketApplicationService>(new HierarchicalLifetimeManager());



            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
        }
    }
}
