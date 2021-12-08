using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Entities.Features;
using CleanArchitecture.SharedAbstractions.Domain;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Repositories
{
    public interface IConfigurationFeatureRepository : IRepository<Feature, FeatureId>
    {
        ValueTask<Feature> GetAsync(FeatureId featureId);

        ValueTask<IEnumerable<Feature>> GetAllAsync();

        ValueTask SaveAsync(Feature feature);
    }
}