using System;
using System.Threading.Tasks;
using CleanArchitecture.MembersRegistration.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace CleanArchitecture.MembersRegistration.Web.Views.Components.EntryLinks
{
    public class EntryLinksViewComponent : ViewComponent
    {
        private readonly Lazy<IUmbracoContentNodeService> _umbracoContentNodeService;

        public EntryLinksViewComponent(Lazy<IUmbracoContentNodeService> umbracoContentNodeService)
            => _umbracoContentNodeService = umbracoContentNodeService;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginPage = _umbracoContentNodeService.Value.GetLoginPage();
            var registrationPage = _umbracoContentNodeService.Value.GetRegistrationPage();

            return View(new EntryLinksViewModel(
                LoginPageUrl: new Uri(
                    uriString: loginPage is not null
                        ? loginPage.Url(mode: UrlMode.Relative)
                        : "login-page",
                    uriKind: UriKind.Relative),
                RegistrationPage: new Uri(
                    uriString: registrationPage is not null
                        ? registrationPage.Url(mode: UrlMode.Relative)
                        : "registration-page",
                    uriKind: UriKind.Relative)));
        }
    }
}