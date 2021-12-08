namespace CleanArchitecture.MembersRegistration.Web.Views.Components.RegistrationForm
{
    public record RegistrationFormViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }
    }
}