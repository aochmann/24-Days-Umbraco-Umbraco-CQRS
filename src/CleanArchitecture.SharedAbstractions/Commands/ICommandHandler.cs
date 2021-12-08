using System.Threading.Tasks;

namespace CleanArchitecture.SharedAbstractions.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        ValueTask HandleAsync(TCommand command);
    }
}