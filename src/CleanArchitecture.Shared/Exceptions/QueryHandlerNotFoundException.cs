using System;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.Shared.Exceptions
{
    public class QueryHandlerNotFoundException : Exception
    {
        public QueryHandlerNotFoundException()
        {
        }

        public QueryHandlerNotFoundException(string message) : base(message)
        {
        }

        public QueryHandlerNotFoundException([NotNull] Type type) : base(type.ToString())
        {
        }

        public QueryHandlerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}