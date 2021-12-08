using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Shared.Exceptions;
using CleanArchitecture.SharedAbstractions.DI;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.MembersRegistration.Web.DI
{
    internal class DependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public DependencyResolver(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public THandler Resolve<THandler>()
        {
            using var scope = _serviceProvider.CreateScope();

            var handler = scope.ServiceProvider.GetService<THandler>();

            return handler is not null
                ? handler
                : throw new DependencyNotFoundException(typeof(THandler));
        }

        public IEnumerable<THandler> ResolveMany<THandler>()
        {
            using var scope = _serviceProvider.CreateScope();
            var handlers = scope.ServiceProvider.GetServices<THandler>();

            return handlers is not null && handlers.Any()
                ? handlers
                : throw new DependencyNotFoundException(typeof(THandler));
        }
    }
}