using System.Diagnostics.CodeAnalysis;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.Commands;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.Queries;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.HandlerDispatchers;
using CleanArchitecture.Shared.Domain;
using CleanArchitecture.Shared.Queries;
using CleanArchitecture.SharedAbstractions.DI;
using Lamar;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.DependencyInjection;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static ServiceRegistry AddInfrastructure([NotNull] this ServiceRegistry registry,
            [NotNull] IUmbracoBuilder umbracoBuilder)
        {
            umbracoBuilder.Services
                .AddSettings()
                .AddProviders();

            _ = umbracoBuilder.Services
                .AddFeatureManagement()
                .AddFeatureFilter<PercentageFilter>()
                .AddFeatureFilter<TimeWindowFilter>();

            return registry.AddInfrastructure(umbracoBuilder.Config);
        }

        internal static ServiceRegistry AddInfrastructure([NotNull] this ServiceRegistry registry, IConfiguration configuration)
        {
            _ = registry.For<IConfiguration>()
                .Use(configuration)
                .Singleton();

            _ = registry.For<ConnectionStrings>()
                .Use(serviceContext => serviceContext.GetService<IConfiguration>()
                    .GetOptions<ConnectionStrings>(
                        "ConnectionStrings",
                        true))
                .Singleton();

            _ = registry.For<IDependencyResolver>()
                .Use<CompositionRoot>()
                .Singleton();

            _ = registry.For<IMediator>()
                .Use<Mediator>()
                .Scoped();

            _ = registry.For<ISender>()
                .Use<Mediator>()
                .Scoped();

            _ = registry.For<IPublisher>()
                .Use<Mediator>()
                .Scoped();

            _ = registry.For<ServiceFactory>()
                .Use(ctx => ctx.GetInstance);

            _ = registry.For<ICommandDispatcher>()
                .Use<CommandDispatcher>()
                .Scoped();

            _ = registry.For<IQueryDispatcher>()
                .Use<QueryDispatcher>()
                .Scoped();

            _ = registry
                .AddSettings()
                .AddServices()
                .AddRepositories()
                .AddMappers()
                .AddQueries(typeof(IQueryHandler<,>));

            return registry;
        }
    }
}