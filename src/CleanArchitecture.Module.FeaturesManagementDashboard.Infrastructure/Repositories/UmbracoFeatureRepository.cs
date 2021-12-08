using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.DTO.Features;
using CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Entities.Features;
using CleanArchitecture.Module.FeaturesManagementDashboard.Domain.Repositories;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Mappers;
using DapperExtensions;
using Umbraco.Cms.Core.Configuration;
using Umbraco.Cms.Core.Configuration.Models;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Repositories
{
    internal class UmbracoFeatureRepository : IUmbracoFeatureRepository
    {
        private readonly ConfigConnectionString _umbracoConnectionString;
        private readonly IFeatureItemMapper _featureItemMapper;
        private readonly IFeatureItemsMapper _featureItemsMapper;
        private readonly IFeatureItemDtoMapper _featureDtoMapper;

        public UmbracoFeatureRepository(ConnectionStrings connectionStrings,
            IFeatureItemMapper featureItemMapper,
            IFeatureItemsMapper featureItemsMapper,
            IFeatureItemDtoMapper featureDtoMapper)
        {
            _umbracoConnectionString = connectionStrings.UmbracoConnectionString;
            _featureItemMapper = featureItemMapper;
            _featureItemsMapper = featureItemsMapper;
            _featureDtoMapper = featureDtoMapper;
        }

        public async ValueTask<bool> ExistsAsync(FeatureId featureId)
        {
            using var connection = new SqlConnection(_umbracoConnectionString.ConnectionString);

            var idPrediction = Predicates.Field<FeatureDto>(field => field.Id, DapperExtensions.Predicate.Operator.Eq, featureId.Id);

            var feature = (await connection.GetListAsync<FeatureDto>(idPrediction))
                ?.FirstOrDefault();

            return feature is not null;
        }

        public async ValueTask<IEnumerable<Feature>> GetAllAsync()
        {
            try
            {
                using var connection = new SqlConnection(_umbracoConnectionString.ConnectionString);

                var features = await connection.GetListAsync<FeatureDto>();

                return features is not null
                    ? _featureItemsMapper.Map(features)
                    : Enumerable.Empty<Feature>();
            }
            catch (Exception)
            {
            }

            return Enumerable.Empty<Feature>();
        }

        public async ValueTask<Feature> GetAsync(FeatureId featureId)
        {
            try
            {
                using var connection = new SqlConnection(_umbracoConnectionString.ConnectionString);

                var idPrediction = Predicates.Field<FeatureDto>(field => field.Id, DapperExtensions.Predicate.Operator.Eq, featureId.Id);

                var feature = (await connection.GetListAsync<FeatureDto>(idPrediction))
                    ?.FirstOrDefault();

                return feature is not null
                    ? _featureItemMapper.Map(feature)
                    : null;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async ValueTask SaveAsync(Feature feature)
        {
            try
            {
                var featureExists = await ExistsAsync(feature.Id);

                using var connection = new SqlConnection(_umbracoConnectionString.ConnectionString);

                var featureDto = _featureDtoMapper.Map(feature);

                if (featureExists)
                {
                    await connection.UpdateAsync<FeatureDto>(featureDto);

                    return;
                }

                await connection.InsertAsync<FeatureDto>(featureDto);
            }
            catch (Exception)
            {
            }
        }
    }
}