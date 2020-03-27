using Autofac;
using MP.Author.Core.Interfaces.UseCases;
using MP.Author.Core.UseCases;

namespace MP.Author.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LogoutUseCase>().As<ILogoutUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ExchangeRefreshTokenUseCase>().As<IExchangeRefreshTokenUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ObjectsUserCase>().As<IObjectsUserCase>().InstancePerLifetimeScope();
            builder.RegisterType<OperationsUserCase>().As<IOperationsUserCase>().InstancePerLifetimeScope();
        }
    }
}
