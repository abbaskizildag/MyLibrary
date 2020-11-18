
using Microsoft.Extensions.Configuration;
using MyLibrary.Business.Abstract;
using MyLibrary.Business.Concrete;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtention
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddDataServices();

            return services;
        }
    }
}