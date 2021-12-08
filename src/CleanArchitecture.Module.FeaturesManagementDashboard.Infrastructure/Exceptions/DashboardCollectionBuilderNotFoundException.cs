using Umbraco.Cms.Core.Dashboards;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Exceptions
{
    public class DashboardCollectionBuilderNotFoundException : InfrastructureException
    {
        public override string Code => "dashboard_collection_builder_not_found";

        public DashboardCollectionBuilderNotFoundException() : base($"{nameof(DashboardCollectionBuilder)} not found. Check if you register this dependency.")
        {
        }
    }
}