using AutoMapper;
using BSynchro.API.MappingProfiles;
using BSynchro.BAL.Interfaces;
using BSynchro.BAL.Services;
using BSynchro.DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BSynchro.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<BSynchroDBContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), bulider =>
                {
                    bulider.CommandTimeout(90);
                });
            });

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
             => services.AddScoped<IAccountService, AccountService>();


        public static IServiceCollection AddAutoMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
