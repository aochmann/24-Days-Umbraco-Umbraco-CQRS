using CleanArchitecture.MembersRegistration.Infrastructure.Logging;
using CleanArchitecture.SharedAbstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.MembersRegistration.Infrastructure.Extensions
{
    internal static class LoggingExtensions
    {
        public static IServiceCollection AddCommandHandlersLogging(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryDecorate(
                typeof(ICommandHandler<>),
                typeof(LoggingCommandHandlerDecorator<>));

            return serviceCollection;
        }
    }
}