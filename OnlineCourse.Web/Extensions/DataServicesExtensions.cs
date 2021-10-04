using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCourse.Data;
using OnlineCourse.Data.Interfaces;
using OnlineCourse.Data.Repositories;
using OnlineCourse.Data.Transactions;

namespace OnlineCourse.Web.Extensions
{
    public static class DataServicesExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUow, Uow>();

            services.AddDbContext<ApplicationDbContext>(opt => 
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}