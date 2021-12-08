using MediatR;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Application.Queries
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : class, IRequest<TResult>
    {
    }
}