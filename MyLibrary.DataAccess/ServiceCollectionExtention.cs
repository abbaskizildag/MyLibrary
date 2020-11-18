
using Microsoft.Extensions.Configuration;
using MyLibrary.DataAccess;
using MyLibrary.DataAccess.Abstract;
using MyLibrary.DataAccess.Concrete;
using MyLibrary.DataAccess.UnitOfWorks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtention
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<MyLibraryDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}