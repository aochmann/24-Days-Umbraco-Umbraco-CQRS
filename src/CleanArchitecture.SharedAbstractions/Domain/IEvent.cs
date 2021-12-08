using System;

namespace CleanArchitecture.SharedAbstractions.Domain
{
    public interface IEvent
    {
        DateTime Created => DateTime.UtcNow;
    }
}