using System;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Dashboards;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Dashboards
{
    [Weight(80)]
    public class FeatureManagementDashboard : IDashboard
    {
        public string Alias => "Our.Umbraco.FeatureManagementDashboard";

        public string[] Sections => new[]
        {
            Umbraco.Cms.Core.Constants.Applications.Settings
        };

        public IAccessRule[] AccessRules => Array.Empty<IAccessRule>();

        public string View => "/App_Plugins/FeatureManagementDashboard/dashboard.html";
    }
}