using IT_Career_GR.Common.Models;
using IT_Career_GR.Common.Services.Abstractions;

namespace IT_Career_GR.Web.Server.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder app)
        {
            return app.Use((context, next) =>
            {
                var serviceProvider = app.ApplicationServices;
                var service = serviceProvider.GetService<ICustomLocalizer>();
                // get culture from request
                var currentCulture = context.Request.Cookies["culture"];
                if (currentCulture is null)
                {
                    currentCulture = "el-GR";
                    context.Response.Cookies.Append("culture", currentCulture.ToString());
                }
                service.Culture = context.Request.Cookies["culture"];
                return next.Invoke();
            });
        }
    }
}
