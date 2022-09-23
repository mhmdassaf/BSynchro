using AutoMapper;
using BSynchro.API.MappingProfiles;
using BSynchro.BAL.Behaviors;
using BSynchro.BAL.Handlers;
using BSynchro.BAL.Handlers.Base;
using BSynchro.BAL.Interfaces;
using BSynchro.BAL.Services;
using BSynchro.Common.Models.Settings;
using BSynchro.DAL.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BSynchro.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<BSynchroDBContext>(opt =>
            //{
            //    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), bulider =>
            //    {
            //        bulider.CommandTimeout(90);
            //    });
            //});
            services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
            services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddSingleton<IMongoClient>(sp => new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString")));
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
             => services.AddScoped<IAccountService, AccountService>();


        public static IServiceCollection AddAutoMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }

        public static IServiceCollection AddMediatRs(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddMediatR(typeof(BaseHandler).Assembly);
            return services;
        }
    }
}
