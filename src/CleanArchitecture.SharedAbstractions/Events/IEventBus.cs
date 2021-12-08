using System.Threading.Tasks;
using CleanArchitecture.SharedAbstractions.Domain;

namespace CleanArchitecture.SharedAbstractions.Events
{
    public interface IEventBus
    {
        ValueTask SendAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}