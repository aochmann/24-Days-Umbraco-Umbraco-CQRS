namespace CleanArchitecture.MembersRegistration.Application.Exceptions
{
    public class MemberAlreadyExistsException : AppException
    {
        public override string Code => "member_already_exists";

        public MemberAlreadyExistsException(string email) : base($"Member {email} already exists.")
        {
        }
    }
}