using IT_Career_GR.Common.Services;
using IT_Career_GR.Common.Services.Abstractions;

namespace IT_Career_GR.Web.Server.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomLocalization(this IServiceCollection services) 
        {
            services.AddSingleton<ICustomLocalizer, CustomLocalizer>();
            return services;
        }
    }
}
