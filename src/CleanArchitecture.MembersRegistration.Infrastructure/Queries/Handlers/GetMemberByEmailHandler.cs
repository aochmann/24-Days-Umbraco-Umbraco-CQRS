using System.Threading.Tasks;
using CleanArchitecture.MembersRegistration.Application.Queries;
using CleanArchitecture.SharedAbstractions.Queries;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace CleanArchitecture.MembersRegistration.Infrastructure.Queries.Handlers
{
    internal class GetMemberByEmailHandler : IQueryHandler<GetMemberByEmail, IMember>
    {
        private readonly IMemberService _memberService;

        public GetMemberByEmailHandler(IMemberService memberService)
            => _memberService = memberService;

        public ValueTask<IMember> HandleAsync(GetMemberByEmail query)
        {
            var member = _memberService.GetByEmail(query.Email);

            return ValueTask.FromResult(member);
        }
    }
}