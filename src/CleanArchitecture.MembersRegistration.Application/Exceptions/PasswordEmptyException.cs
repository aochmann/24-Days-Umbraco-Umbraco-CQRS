namespace CleanArchitecture.MembersRegistration.Application.Exceptions
{
    public class PasswordEmptyException : AppException
    {
        public override string Code => "password_empty";

        public PasswordEmptyException() : base("Password is empty.")
        {
        }
    }
}