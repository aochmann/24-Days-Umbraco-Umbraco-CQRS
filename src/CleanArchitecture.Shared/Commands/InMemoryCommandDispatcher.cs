using System;
using System.Threading.Tasks;
using CleanArchitecture.Shared.Exceptions;
using CleanArchitecture.SharedAbstractions.Commands;
using CleanArchitecture.SharedAbstractions.DI;

namespace CleanArchitecture.Shared.Commands
{
    public class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IDependencyResolver _dependencyResolver;

        public InMemoryCommandDispatcher(IDependencyResolver dependencyResolver)
            => _dependencyResolver = dependencyResolver;

        public async ValueTask DispatchAsync<TCommand>(TCommand command)
            where TCommand : class, ICommand
        {
            try
            {
                var handler = _dependencyResolver.Resolve<ICommandHandler<TCommand>>();

                await handler.HandleAsync(command);
            }
            catch (DependencyNotFoundException dependencyNotFoundException)
            {
                throw new CommandHandlerNotFoundException(
                    $"Command handler for {typeof(TCommand).Name} not found.",
                    dependencyNotFoundException);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}