using CleanArchitecture.Module.FeaturesManagementDashboard.Application.DTO.Features;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Constants;
using Umbraco.Cms.Infrastructure.Migrations;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Migrations
{
    internal class CreateFeatureManagementTableMigration : MigrationBase
    {
        public CreateFeatureManagementTableMigration(IMigrationContext context) : base(context)
        {
        }

        protected override void Migrate()
        {
            if (TableExists(FeatureManagementConstants.TableName))
            {
                return;
            }

            var idColumnName = nameof(FeatureDto.Id);
            var nameColumnName = nameof(FeatureDto.Name);
            var statusColumnName = nameof(FeatureDto.Status);

            var tableBuilder = Create
                .Table(FeatureManagementConstants.TableName);

            tableBuilder
                .WithColumn(idColumnName)
                    .AsString()
                    .NotNullable()
                .WithColumn(nameColumnName)
                    .AsString()
                    .NotNullable()
                .WithColumn(statusColumnName)
                    .AsBoolean()
                .Do();
        }
    }
}