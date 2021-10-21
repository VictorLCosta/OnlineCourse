using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourse.Web.Filters;

namespace OnlineCourse.Web.Extensions 
{
    public static class WebServicesExtensions
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSession(opt => {
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddMvc(config => {
                config.Filters.Add(typeof(ExceptionFilter));
            });

            return services;
        }
    }
}