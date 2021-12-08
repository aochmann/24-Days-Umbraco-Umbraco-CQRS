using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Extensions
{
    internal static class ProvidersExtensions
    {
        public static IServiceCollection AddProviders(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddSingleton<IFeatureDefinitionProvider, UmbracoFeatureDefinitionProvider>();
    }
}