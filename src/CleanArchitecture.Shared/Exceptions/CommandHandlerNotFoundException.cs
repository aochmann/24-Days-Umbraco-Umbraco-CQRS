using System;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.Shared.Exceptions
{
    public class CommandHandlerNotFoundException : Exception
    {
        public CommandHandlerNotFoundException()
        {
        }

        public CommandHandlerNotFoundException(string message) : base(message)
        {
        }

        public CommandHandlerNotFoundException([NotNull] Type type) : base(type.ToString())
        {
        }

        public CommandHandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}