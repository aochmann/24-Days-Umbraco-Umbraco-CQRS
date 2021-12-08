using System;
using System.Threading.Tasks;
using CleanArchitecture.MembersRegistration.Application.Commands;
using CleanArchitecture.MembersRegistration.Application.Exceptions;
using CleanArchitecture.MembersRegistration.Application.Services;
using CleanArchitecture.SharedAbstractions.Commands;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Extensions;

namespace CleanArchitecture.MembersRegistration.Web.Controllers.Actions
{
    public class RegistrationSurfaceController : SurfaceController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly Lazy<IUmbracoContentNodeService> _umbracoContentNodeService;

        public RegistrationSurfaceController(IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider,
            ICommandDispatcher commandDispatcher,
            Lazy<IUmbracoContentNodeService> umbracoContentNodeService)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _commandDispatcher = commandDispatcher;
            _umbracoContentNodeService = umbracoContentNodeService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ValueTask<IActionResult> Register(RegisterMember command)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            try
            {
                await _commandDispatcher.DispatchAsync(command);
            }
            catch (System.Exception exception)
            {
                switch (exception)
                {
                    case MemberAlreadyExistsException memberAlreadyExistsException:
                        {
                            ModelState.AddModelError(memberAlreadyExistsException.Code, "Bad username or password");
                        }
                        break;

                    case PasswordEmptyException passwordEmptyException:
                        {
                            ModelState.AddModelError(passwordEmptyException.Code, "Empty password");
                        }
                        break;

                    case PasswordNotMatchConfirmationException passwordNotMatchConfirmationException:
                        {
                            ModelState.AddModelError(passwordNotMatchConfirmationException.Code, "Passwords not match.");
                        }
                        break;

                    default:
                        throw;
                }

                return CurrentUmbracoPage();
            }

            var homePage = _umbracoContentNodeService.Value.GetHomePage();

            return Redirect(homePage is not null
                ? homePage.Url(mode: UrlMode.Relative)
                : "/");
        }
    }
}