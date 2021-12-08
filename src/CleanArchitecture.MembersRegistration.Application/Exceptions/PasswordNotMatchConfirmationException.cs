namespace CleanArchitecture.MembersRegistration.Application.Exceptions
{
    public class PasswordNotMatchConfirmationException : AppException
    {
        public override string Code => "password_not_match_confirmation";

        public PasswordNotMatchConfirmationException() : base("Password not match confirmation.")
        {
        }
    }
}