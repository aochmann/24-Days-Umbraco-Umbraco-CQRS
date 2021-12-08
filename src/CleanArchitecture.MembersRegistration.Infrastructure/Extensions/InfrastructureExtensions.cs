using System.Diagnostics.CodeAnalysis;
using CleanArchitecture.Shared.Commands;
using CleanArchitecture.Shared.Queries;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace CleanArchitecture.MembersRegistration.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IUmbracoBuilder AddInfrastructure([NotNull] this IUmbracoBuilder umbracoBuilder)
        {
            _ = umbracoBuilder.Services
                .AddInfrastructure();

            return umbracoBuilder
                .AddUmbracoHandlers();
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddQueries()
                .AddCommandDispatcher<InMemoryCommandDispatcher>()
                .AddQueryDispatcher<InMemoryQueryDispatcher>()
                .AddCommandHandlersLogging()
                .AddServices();
    }
}