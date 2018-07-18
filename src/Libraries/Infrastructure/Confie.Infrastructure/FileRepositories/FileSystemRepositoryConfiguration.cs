using System.Configuration;

namespace Confie.Infrastructure.FileRepositories
{
    public class FileSystemRepositoryConfiguration
    {
        public bool Overwrite { get; set; }

        public static FileSystemRepositoryConfiguration FromAppConfig()
        {
            return new FileSystemRepositoryConfiguration
            {
                Overwrite = GetOverwriteValue()
            };
        }

        private static bool GetOverwriteValue()
        {
            bool.TryParse(ConfigurationManager.AppSettings["FileSystemRepository.Overwrite"], out var overwrite);

            return overwrite;
        }
    }
}