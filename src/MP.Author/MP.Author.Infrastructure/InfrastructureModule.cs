using Autofac;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Infrastructure.Data.Repositories;
using Module = Autofac.Module;

namespace MP.Author.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            
        }
    }
}
