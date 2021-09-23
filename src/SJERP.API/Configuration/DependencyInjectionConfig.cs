
using SJERP.Domain.Interfaces;
using SJERP.Domain.Services;
using SJERP.Infrastructure.Context;
using SJERP.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace SJERP.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<SJERPDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
