using System;
using System.Threading.Tasks;
using CleanArchitecture.Module.FeaturesManagementDashboard.Application.Queries;
using MediatR;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.HandlerDispatchers
{
    internal class QueryDispatcher : IQueryDispatcher
    {
        private readonly ISender _querySender;

        public QueryDispatcher(ISender querySender)
            => _querySender = querySender;

        public async ValueTask<TResult> QueryAsync<TQuery, TResult>(IQuery<TQuery, TResult> query)
            where TQuery : class, IQuery<TQuery, TResult>
        {
            try
            {
                return await _querySender.Send<TResult>(query);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}