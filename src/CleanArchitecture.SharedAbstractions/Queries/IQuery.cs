namespace CleanArchitecture.SharedAbstractions.Queries
{
    public interface IQuery
    {
    }

    public interface IQuery<in TQuery, out TResult> : IQuery where TQuery : class
    {
    }
}