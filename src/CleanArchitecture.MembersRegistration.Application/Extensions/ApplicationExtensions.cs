using System.Diagnostics.CodeAnalysis;
using CleanArchitecture.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace CleanArchitecture.MembersRegistration.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IUmbracoBuilder AddApplication([NotNull] this IUmbracoBuilder umbracoBuilder)
        {
            _ = umbracoBuilder.Services
                .AddApplication();

            return umbracoBuilder;
        }

        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
            => serviceCollection.AddCommands();
    }
}