using CleanArchitecture.SharedAbstractions.Commands;

namespace CleanArchitecture.MembersRegistration.Application.Commands
{
    public record RegisterMember(string Email, string Password, string PasswordConfirmation) : ICommand;
}