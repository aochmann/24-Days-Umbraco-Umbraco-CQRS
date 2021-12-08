using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Entities.Features;
using CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Repositories
{
    internal class ConfigurationRepository : IConfigurationFeatureRepository
    {
        private readonly IConfigurationSection _featureManagementSection;
        private readonly IConfiguration _configuration;

        public ConfigurationRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            _featureManagementSection = configuration
                           .GetSection("FeatureManagement");
        }

        public async ValueTask<IEnumerable<Feature>> GetAllAsync()
            => _featureManagementSection
                .GetChildren()
                .Select(featureSection => GetFeature(featureSection))
                .Where(feature => feature is not null)
                .ToArray();

        public async ValueTask<Feature> GetAsync(FeatureId featureId)
            => _featureManagementSection
                .GetChildren()
                .Select(featureSection => GetFeature(featureSection))
                .Where(feature => feature is not null)
                .FirstOrDefault(feature => feature.Id.Equals(featureId));

        public async ValueTask SaveAsync(Feature feature)
        {
            var featureSection = GetFeatureSection(feature.Name);

            featureSection.Value = feature.Status.ToString();

            var root = _configuration as IConfigurationRoot;

            var providers = root.Providers
                .Where(provider =>
                    provider.TryGet(featureSection.Path, out var _))
                .ToArray();

            foreach (var provider in providers)
            {
                // for now it updated in memory only
                provider.Set(featureSection.Path, featureSection.Value);
            }
        }

        private IConfigurationSection GetFeatureSection([NotNull] string featureName)
            => _featureManagementSection.GetChildren()
                .FirstOrDefault(section => section.Key.Equals(featureName));

        private static Feature GetFeature(IConfigurationSection featureSection)
        {
            var subConfigurations = featureSection.GetChildren();

            if (subConfigurations is null || !subConfigurations.Any())
            {
                var featureName = featureSection.Key;
                var featureStatus = featureSection.Get<bool>();

                return new Feature(
                   featureName,
                   featureStatus);
            }

            return null;
        }
    }
}