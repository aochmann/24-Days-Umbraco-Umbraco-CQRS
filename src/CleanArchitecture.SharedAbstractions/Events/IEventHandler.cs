using System.Threading.Tasks;
using CleanArchitecture.SharedAbstractions.Domain;

namespace CleanArchitecture.SharedAbstractions.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        ValueTask HandleAsync(TEvent @event);
    }
}