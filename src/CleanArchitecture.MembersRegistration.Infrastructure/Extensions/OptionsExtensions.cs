using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.MembersRegistration.Infrastructure.Extensions
{
    internal static class OptionsExtensions
    {
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName)
            where TModel : new()
        {
            var model = new TModel();

            configuration.GetSection(sectionName).Bind(model);

            return model;
        }
    }
}