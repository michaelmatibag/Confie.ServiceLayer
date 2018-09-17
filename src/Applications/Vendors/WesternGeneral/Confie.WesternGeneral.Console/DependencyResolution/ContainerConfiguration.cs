using System.IO.Abstractions;
using Autofac;
using Confie.Infrastructure.Application;
using Confie.Infrastructure.Configuration;
using Confie.Infrastructure.Factories;
using Confie.Infrastructure.FileHandling;
using Confie.Infrastructure.FileRepositories;
using Confie.WesternGeneral.ClaimsRepository;
using Confie.WesternGeneral.ServiceLogic.Applications;
using Confie.WesternGeneral.ServiceLogic.Configuration;

namespace Confie.WesternGeneral.Console.DependencyResolution
{
    public static class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ImportClaimsApplication>().As<IApplication>();
            builder.RegisterType<ImportClaimsConfiguration>().AsSelf();
            builder.RegisterType<FileSystemRepository>().As<IFileRepository>();
            builder.RegisterType<FixedFileHandling>().As<IFileHandling>();
            builder.RegisterType<ClaimsRepository.ClaimsRepository>().As<IClaimsRepository>();
            builder.RegisterType<ConfigurationRepository>().As<IConfigurationRepository>();
            builder.RegisterType<FileSystem>().As<IFileSystem>();
            builder.RegisterType<ClaimsContextFactory>().As<IFactory<ClaimsContext>>();

            return builder.Build();
        }
    }
}