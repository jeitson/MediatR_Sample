using System;
using System.Linq;
using System.Reflection;
using MediatR;
using Unity;

namespace Project.Infrastructure
{
    public static class UnityConfiguration
    {
        static UnityConfiguration()
        {
            Container = new UnityContainer();
            Container.RegisterType<IMediator, Mediator>();
            Container.RegisterInstance<ServiceFactory>(t => Container.Resolve(t));
            Container.RegisterInstance<ServiceFactory>(t => Container.ResolveAll(t));

            var requestHandlerType = typeof(IRequestHandler<,>);
            var handlers =
                Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Any(i => IsSubclassOfRawGeneric(requestHandlerType, i)));
            foreach (var handler in handlers)
            {
                var interfaces = handler.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    Container.RegisterType(@interface, handler);
                }
            }
        }

        static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var currentType = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == currentType)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        public static IUnityContainer Container { get; }
    }
}