using System.Threading.Tasks;
using CleanArchitecture.MembersRegistration.Application.Exceptions;
using CleanArchitecture.MembersRegistration.Domain.CmsModels.Generated;
using CleanArchitecture.SharedAbstractions.Commands;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;

namespace CleanArchitecture.MembersRegistration.Application.Commands.Handlers
{
    internal class RegisterMemberHandler : ICommandHandler<RegisterMember>
    {
        private readonly IMemberManager _memberManager;
        private readonly IMemberService _memberService;

        public RegisterMemberHandler(IMemberManager memberManager, IMemberService memberService)
        {
            _memberManager = memberManager;
            _memberService = memberService;
        }

        public async ValueTask HandleAsync(RegisterMember command)
        {
            var existingMember = _memberService.GetByEmail(command.Email);

            if (existingMember is not null)
            {
                throw new MemberAlreadyExistsException(command.Email);
            }

            if (string.IsNullOrWhiteSpace(command.Password) || string.IsNullOrWhiteSpace(command.PasswordConfirmation))
            {
                throw new PasswordEmptyException();
            }

            if (!command.Password.Equals(command.PasswordConfirmation))
            {
                throw new PasswordNotMatchConfirmationException();
            }

            var member = _memberService.CreateWithIdentity(
                command.Email,
                command.Email,
                command.Password,
                Member.ModelTypeAlias);

            _memberService.Save(member);
        }
    }
}