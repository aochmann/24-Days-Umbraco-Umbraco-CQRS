using System.Reflection;
using CleanArchitecture.SharedAbstractions.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Shared.Mappers
{
    public static class MappersExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IMapper<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            return services;
        }
    }
}