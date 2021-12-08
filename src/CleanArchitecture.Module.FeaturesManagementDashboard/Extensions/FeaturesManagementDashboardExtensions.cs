using System.Diagnostics.CodeAnalysis;
using Umbraco.Cms.Core.DependencyInjection;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Extensions
{
    public static class FeaturesManagementDashboardExtensions
    {
        public static IUmbracoBuilder AddFeaturesManagementDashboard([NotNull] this IUmbracoBuilder builder)
            => new ModuleStartup(builder)
                .Build();
    }
}