using Autofac;
using Confie.Infrastructure.Application;
using Confie.WesternGeneral.Console.DependencyResolution;
using NUnit.Framework;
using Shouldly;

namespace Confie.WesternGeneral.UnitTests.ServiceLogic.Applications
{
    [TestFixture]
    public class ImportClaimsApplicationTests
    {
        [Test]
        public void ImportClaimsApplication_Resolves()
        {
            var container = ContainerConfiguration.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var application = scope.Resolve<IApplication>();

                application.ShouldNotBeNull();
            }
        }
    }
}