using System;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.Shared.Exceptions
{
    public class DependencyNotFoundException : Exception
    {
        public DependencyNotFoundException()
        {
        }

        public DependencyNotFoundException(string message) : base(message)
        {
        }

        public DependencyNotFoundException([NotNull] Type type) : base(type.ToString())
        {
        }

        public DependencyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}