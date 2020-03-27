using Autofac;
using MP.Author.Core.Interfaces.Gateways.Repositories;
using MP.Author.Core.Interfaces.Services;
using MP.Author.Infrastructure.Auth;
using MP.Author.Infrastructure.Data.Repositories;
using MP.Author.Infrastructure.Interfaces;
using MP.Author.Infrastructure.Logging;
using Module = Autofac.Module;

namespace MP.Author.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRoleRepository>().As<IUserRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ObjectsRepository>().As<IObjectsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OperationsRepository>().As<IOperationsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PermissionsRepository>().As<IPermissionsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RolePermissionRepository>().As<IRolePermissionRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<JwtTokenHandler>().As<IJwtTokenHandler>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<TokenFactory>().As<ITokenFactory>().SingleInstance();
            builder.RegisterType<JwtTokenValidator>().As<IJwtTokenValidator>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
        }
    }
}
