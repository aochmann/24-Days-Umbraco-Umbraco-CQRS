namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Settings
{
    public record FeaturesManagementDashboardSettings
    {
        public bool Enabled { get; init; }
        public bool Override { get; init; }
    }
}