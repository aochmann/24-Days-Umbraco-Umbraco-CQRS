using Umbraco.Cms.Core.DependencyInjection;

namespace CleanArchitecture.MembersRegistration.Infrastructure.Extensions
{
    internal static class UmbracoHandlers
    {
        public static IUmbracoBuilder AddUmbracoHandlers(this IUmbracoBuilder umbracoBuilder)
        {
            // Add handlers, example:
            // umbracoBuilder.AddNotificationAsyncHandler<ContentPublishedNotification, UmbracoContentNotificationHandler>();

            return umbracoBuilder;
        }
    }
}