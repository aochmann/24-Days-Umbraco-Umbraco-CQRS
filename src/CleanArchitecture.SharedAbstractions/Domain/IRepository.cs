namespace CleanArchitecture.SharedAbstractions.Domain
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity, TEntityIdentity> : IRepository
        where TEntity : AggregateRoot<TEntityIdentity>
    {
    }
}