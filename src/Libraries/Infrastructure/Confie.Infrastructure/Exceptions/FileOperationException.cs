using System;

namespace Confie.Infrastructure.Exceptions
{
    public class FileOperationException : Exception
    {
        public FileOperationException(string message) : base(message)
        {
        }
    }
}