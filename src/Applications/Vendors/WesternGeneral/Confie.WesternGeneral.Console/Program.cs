using Autofac;
using Confie.Infrastructure.Application;
using Confie.WesternGeneral.Console.DependencyResolution;

namespace Confie.WesternGeneral.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = ContainerConfiguration.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var application = scope.Resolve<IApplication>();

                application.Run();
            }
        }
    }
}