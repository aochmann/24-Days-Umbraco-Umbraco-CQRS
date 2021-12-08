using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Exceptions;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core.Manifest;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Dashboards.CollectionBuilders
{
    public class FeatureManagementDashboardCollectionBuilder : DashboardCollectionBuilder
    {
        protected override FeatureManagementDashboardCollectionBuilder This => this;

        protected override IEnumerable<IDashboard> CreateItems(IServiceProvider factory)
        {
            var dashboardCollectionBuilder = factory
                    .GetService<DashboardCollectionBuilder>();

            if (dashboardCollectionBuilder is null)
            {
                throw new DashboardCollectionBuilderNotFoundException();
            }

            var featuresManagamentDashboardSettings = factory
                    .GetService<FeaturesManagementDashboardSettings>();

            var manifestParser = factory.GetRequiredService<IManifestParser>();

            var dashboardTypes = dashboardCollectionBuilder.GetTypes();

            var allTypes = dashboardTypes;

            if (featuresManagamentDashboardSettings is not null
                && featuresManagamentDashboardSettings.Enabled)
            {
                var featureManagementDashboardTypes = GetTypes();
                allTypes = allTypes.Concat(featureManagementDashboardTypes);
            }

            var dashboards = allTypes
                .Select(type => CreateItem(factory, type))
                .ToArray();

            return dashboards.Concat(manifestParser.CombinedManifest.Dashboards)
                .Where(dashboard => !string.IsNullOrWhiteSpace(dashboard.Alias))
                .OrderBy(GetWeight)
                .ToArray();
        }

        private int GetWeight(IDashboard dashboard) => dashboard switch
        {
            ManifestDashboard manifestDashboardDefinition => manifestDashboardDefinition.Weight,
            _ => GetWeight(dashboard.GetType())
        };
    }
}