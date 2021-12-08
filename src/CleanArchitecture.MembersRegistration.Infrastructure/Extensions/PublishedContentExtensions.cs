using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace CleanArchitecture.MembersRegistration.Infrastructure.Extensions
{
    internal static class PublishedContentExtensions
    {
        public static TChild FirstChildOrDefault<TChild>(this IPublishedContent publishedContent, IVariationContextAccessor variationContextAccessor, string culture = null)
            where TChild : class, IPublishedContent
            => publishedContent?.FirstChild<TChild>(variationContextAccessor, culture);
    }
}