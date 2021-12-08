using System;
using System.Reflection;
using CleanArchitecture.SharedAbstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Shared.Commands
{
    public static class CommandsExtensions
    {
        public static IServiceCollection AddCommandDispatcher<TDispatcher>(this IServiceCollection services)
            where TDispatcher : class, ICommandDispatcher
            => services.AddSingleton<ICommandDispatcher, TDispatcher>();

        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddCommands(this IServiceCollection services,
            Type commandHandlerType)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(commandHandlerType))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}