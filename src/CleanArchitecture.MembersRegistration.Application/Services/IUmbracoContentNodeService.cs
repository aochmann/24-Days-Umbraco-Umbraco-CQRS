using CleanArchitecture.MembersRegistration.Domain.CmsModels.Generated;

namespace CleanArchitecture.MembersRegistration.Application.Services
{
    public interface IUmbracoContentNodeService
    {
        HomePage GetHomePage();

        RegistrationPage GetRegistrationPage();

        LoginPage GetLoginPage();
    }
}