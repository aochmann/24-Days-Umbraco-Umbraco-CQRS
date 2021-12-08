using System.Reflection;
using CleanArchitecture.SharedAbstractions.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Shared.Domain
{
    public static class RepositoriesExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IRepository<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}