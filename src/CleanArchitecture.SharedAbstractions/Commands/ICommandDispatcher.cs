using System.Threading.Tasks;

namespace CleanArchitecture.SharedAbstractions.Commands
{
    public interface ICommandDispatcher
    {
        ValueTask DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}