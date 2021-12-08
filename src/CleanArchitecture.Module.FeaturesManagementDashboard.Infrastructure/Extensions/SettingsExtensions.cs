using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Extensions
{
    internal static class SettingsExtensions
    {
        public static IServiceCollection AddSettings(this IServiceCollection serviceCollection)
            => serviceCollection.AddSingleton<FeaturesManagementDashboardSettings>(factory
                => factory.GetService<IConfiguration>()
                        .GetFeaturesManagementDashboardSettings());

        public static FeaturesManagementDashboardSettings GetFeaturesManagementDashboardSettings(this IConfiguration configuration)
            => configuration.GetOptions<FeaturesManagementDashboardSettings>("FeaturesManagementDashboard");
    }
}