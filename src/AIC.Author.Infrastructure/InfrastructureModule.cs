using Autofac;
using AIC.Author.Core.Interfaces.Gateways.Repositories;
using AIC.Author.Core.Interfaces.Services;
using AIC.Author.Infrastructure.Auth;
using AIC.Author.Infrastructure.Data.Repositories;
using AIC.Author.Infrastructure.Interfaces;
using AIC.Author.Infrastructure.Logging;
using Module = Autofac.Module;

namespace AIC.Author.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<JwtTokenHandler>().As<IJwtTokenHandler>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<TokenFactory>().As<ITokenFactory>().SingleInstance();
            builder.RegisterType<JwtTokenValidator>().As<IJwtTokenValidator>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
        }
    }
}
