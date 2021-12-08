using System.Linq;
using CleanArchitecture.MembersRegistration.Application.Services;
using CleanArchitecture.MembersRegistration.Domain.CmsModels.Generated;
using CleanArchitecture.MembersRegistration.Infrastructure.Extensions;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace CleanArchitecture.MembersRegistration.Infrastructure.Services
{
    public class UmbracoContentNodeService : IUmbracoContentNodeService
    {
        private readonly IPublishedContentQuery _publishedContentQuery;
        private readonly IVariationContextAccessor _variationContextAccessor;

        public UmbracoContentNodeService(IPublishedContentQuery publishedContentQuery, IVariationContextAccessor variationContextAccessor)
                => (_publishedContentQuery, _variationContextAccessor) = (publishedContentQuery, variationContextAccessor);

        public HomePage GetHomePage()
            => _publishedContentQuery
                .ContentAtRoot()
                .FirstOrDefault<HomePage>();

        public LoginPage GetLoginPage()
            => GetHomePage()
                ?.FirstChildOrDefault<LoginPage>(_variationContextAccessor);

        public RegistrationPage GetRegistrationPage()
            => GetHomePage()
                ?.FirstChildOrDefault<RegistrationPage>(_variationContextAccessor);
    }
}