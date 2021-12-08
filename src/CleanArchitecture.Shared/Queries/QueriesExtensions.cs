using System;
using System.Reflection;
using CleanArchitecture.SharedAbstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Shared.Queries
{
    public static class QueriesExtensions
    {
        public static IServiceCollection AddQueryDispatcher<TDispatcher>(this IServiceCollection services)
            where TDispatcher : class, IQueryDispatcher
            => services.AddSingleton<IQueryDispatcher, TDispatcher>();

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddQueries(this IServiceCollection services, Type queryHandlerType)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(queryHandlerType))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}