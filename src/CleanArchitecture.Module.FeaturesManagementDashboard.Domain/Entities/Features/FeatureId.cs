using System;
using CleanArchitecture.SharedAbstractions.ValueObjects;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Entities.Features
{
    public class FeatureId : ValueObject<string>
    {
        public string Id { get; set; }

        public FeatureId(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Id = name;
        }

        public FeatureId(FeatureId featureId)
        {
            if (featureId is null)
            {
                throw new ArgumentNullException(nameof(featureId));
            }

            Id = featureId.Id;
        }
    }
}