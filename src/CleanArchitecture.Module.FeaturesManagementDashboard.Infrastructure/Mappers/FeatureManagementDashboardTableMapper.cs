using CleanArchitecture.Module.FeaturesManagementDashboard.Application.DTO.Features;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Constants;
using DapperExtensions.Mapper;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Mappers
{
    internal class FeatureManagementDashboardTableMapper : ClassMapper<FeatureDto>
    {
        public FeatureManagementDashboardTableMapper()
        {
            Table(FeatureManagementConstants.TableName);

            AutoMap();
        }
    }
}