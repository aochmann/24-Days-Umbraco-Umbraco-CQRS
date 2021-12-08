namespace CleanArchitecture.SharedAbstractions.Domain
{
    public abstract class AggregateRoot<TIdentity>
    {
        public TIdentity Id { get; protected set; }
    }
}