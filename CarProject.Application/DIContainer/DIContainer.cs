using CarProject.Application.Mapping;
using CarProject.Application.ServiceInterfaces;
using CarProject.Application.Services;
using CarProject.Domain.Interfaces;
using CarProject.Infrastructure.Context;
using CarProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarProject.Application.DIContainer
{
    public static class DIContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("defaultConnection"), b => b.MigrationsAssembly("CarProject.Infrastructure")));

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IBoatRepository, BoatRepository>();

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IBoatService, BoatService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
