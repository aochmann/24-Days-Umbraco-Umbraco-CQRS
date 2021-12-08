using CleanArchitecture.Module.FeaturesManagementDashboard.Application.DI;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.Extensions;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure;
using CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Extensions;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.DependencyInjection;

namespace CleanArchitecture.Module.FeaturesManagementDashboard
{
    internal class ModuleStartup
    {
        private readonly IUmbracoBuilder _umbracoBuilder;

        public ModuleStartup(IUmbracoBuilder umbracoBuilder)
            => _umbracoBuilder = umbracoBuilder;

        public IUmbracoBuilder Build()
        {
            var container = new Container(registry =>
            {
                registry = registry
                    .AddApplication()
                    .AddInfrastructure(_umbracoBuilder);
            });

            _ = _umbracoBuilder.Services
                .AddSingleton<ICompositionRoot>(new CompositionRoot(container));

            return _umbracoBuilder;
        }
    }
}