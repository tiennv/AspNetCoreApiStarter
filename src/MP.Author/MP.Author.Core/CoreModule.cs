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
            builder.RegisterType<ObjectsUseCase>().As<IObjectsUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<OperationsUseCase>().As<IOperationsUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<PermissionsUseCase>().As<IPermissionsUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RolePermissionUseCase>().As<IRolePermissionUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RoleUseCase>().As<IRoleUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<UserRoleUseCase>().As<IUserRoleUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<MenusUseCase>().As<IMenusUseCase>().InstancePerLifetimeScope();
        }
    }
}
