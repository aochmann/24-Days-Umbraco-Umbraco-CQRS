using System.Diagnostics.CodeAnalysis;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.Commands;
using CleanArchitecture.Shared.Commands;
using Lamar;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static ServiceRegistry AddApplication([NotNull] this ServiceRegistry registry)
        {
            _ = registry.AddCommands(typeof(ICommandHandler<>));

            return registry;
        }
    }
}