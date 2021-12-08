using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Module.FeaturesManagementDashboard.Infrastructure.Extensions
{
    internal static class OptionsExtensions
    {
        public static TModel GetOptions<TModel>(this IConfiguration configuration,
            string sectionName,
            bool bindNonPublicProperties = false)
            where TModel : new()
        {
            var model = new TModel();

            configuration.GetSection(sectionName)
                .Bind(
                    model,
                    binderOptions => binderOptions.BindNonPublicProperties = bindNonPublicProperties);

            return model;
        }
    }
}