using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Confie.Infrastructure.DependencyResolution;
using LazyCache;

namespace Confie.Logging.WebApi.DependencyResolution
{
    public class LoggingServiceLogicFeature
    {
        public static void DependencyBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(x => x.GetCustomAttribute<InjectableAttribute>() != null)
                .AsImplementedInterfaces()
                .InstancePerRequest();
            builder.RegisterType<CachingService>()
                .As<IAppCache>();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}