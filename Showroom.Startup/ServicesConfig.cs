using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Showroom.Business.Services.Register;
using Showroom.Domain.Contracts.Repositories;
using Showroom.Domain.Contracts.Repositories.Register;
using Showroom.Domain.Contracts.Services.Register;
using Showroom.Persistence.Data;
using Showroom.Persistence.Repositories.Register;
using Showroom.Persistence.Transaction;

namespace Showroom.Startup
{
    public class ServicesConfig
    {
        public static void DependeceResolver(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ShowroomDataContext, ShowroomDataContext>();


            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }

        public static void DbContextConfig(IServiceCollection services)
        {
            services.AddDbContext<ShowroomDataContext>(options =>
                options.UseInMemoryDatabase("Showroom"));
        }
    }
}