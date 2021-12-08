using System.Threading.Tasks;
using CleanArchitecture.SharedAbstractions.Domain;

namespace CleanArchitecture.SharedAbstractions.Events
{
    public interface IEventDispatcher
    {
        ValueTask DispatchAsync<TEvent>(TEvent @event) where TEvent : IEvent;

        void Subscribe();
    }
}