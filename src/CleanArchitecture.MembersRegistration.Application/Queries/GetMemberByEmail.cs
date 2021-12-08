using CleanArchitecture.SharedAbstractions.Queries;
using Umbraco.Cms.Core.Models;

namespace CleanArchitecture.MembersRegistration.Application.Queries
{
    public record GetMemberByEmail(string Email) : IQuery<GetMemberByEmail, IMember>;
}