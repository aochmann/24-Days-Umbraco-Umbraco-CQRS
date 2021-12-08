using CleanArchitecture.MembersRegistration.Application.Services;
using CleanArchitecture.MembersRegistration.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.MembersRegistration.Infrastructure.Extensions
{
    internal static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddScoped<IUmbracoContentNodeService, UmbracoContentNodeService>();
    }
}