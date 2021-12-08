using System;
using System.Threading.Tasks;
using CleanArchitecture.MembersRegistration.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace CleanArchitecture.MembersRegistration.Web.Views.Components.Authentication
{
    public class AuthenticationViewComponent : ViewComponent
    {
        private readonly Lazy<IUmbracoContentNodeService> _umbracoContentNodeService;

        public AuthenticationViewComponent(Lazy<IUmbracoContentNodeService> umbracoContentNodeService)
            => _umbracoContentNodeService = umbracoContentNodeService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var registrationPage = _umbracoContentNodeService.Value.GetRegistrationPage();

            return View(new AuthenticationViewModel(
                           RegistrationPageUrl: new Uri(
                               uriString: registrationPage is not null
                                ? registrationPage.Url(mode: UrlMode.Relative)
                                : "/registration-page",
                               uriKind: UriKind.Relative)));
        }
    }
}