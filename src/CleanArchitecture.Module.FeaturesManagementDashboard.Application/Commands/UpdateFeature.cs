namespace CleanArchitecture.Module.FeaturesManagementDashboard.Application.Commands
{
    public record UpdateFeature(string FeatureId, bool Status) : ICommand;
}