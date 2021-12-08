using CleanArchitecture.SharedAbstractions.Domain;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Entities.Features
{
    public class Feature : AggregateRoot<FeatureId>
    {
        public string Name { get; set; }

        public bool Status { get; set; }

        public Feature(string name, bool status)
        {
            Id = new FeatureId(name);
            Status = status;
            Name = name;
        }

        public void UpdateStatus(bool status)
            => Status = status;
    }
}