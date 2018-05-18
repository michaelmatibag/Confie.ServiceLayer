using System;

namespace Confie.Infrastructure.Exceptions
{
    public class ApplicationConfigurationException : Exception
    {
        public ApplicationConfigurationException(string message) : base(message) { }
    }
}