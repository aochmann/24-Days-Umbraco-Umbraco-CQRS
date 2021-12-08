using System.Diagnostics.CodeAnalysis;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Dashboards;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Dashboards.CollectionBuilders;
using Umbraco.Cms.Core.DependencyInjection;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Extensions
{
    internal static class DashboardExtensions
    {
        public static IUmbracoBuilder AddDashboard([NotNull] this IUmbracoBuilder builder)
        {
            _ = builder.WithFeatureManagementDashboard()
                                     .Add<FeatureManagementDashboard>();

            return builder;
        }
    }
}