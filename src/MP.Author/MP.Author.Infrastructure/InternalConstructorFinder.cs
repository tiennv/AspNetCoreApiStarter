using Autofac.Core.Activators.Reflection;
using System;
using System.Linq;
using System.Reflection;

namespace MP.Author.Infrastructure
{
    public class InternalConstructorFinder : IConstructorFinder
    {
        public ConstructorInfo[] FindConstructors(Type t) => t.GetTypeInfo().DeclaredConstructors.Where(c => !c.IsPrivate && !c.IsPublic).ToArray();
    }
}
