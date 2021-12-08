namespace CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Exceptions
{
    public class FeatureNotFoundException : DomainException
    {
        public override string Code => "feature_not_found";

        public FeatureNotFoundException(string featureName) : base($"Feature configuration ({featureName}) not found.")
        {
        }
    }
}