﻿using Lucky.Entities.Interfaces;
using Lucky.Repositories.EFCore;
using Lucky.Repositories.EFCore.Repositories;
using Lucky.UseCases.CreateUser;
using Lucky.UseCases.ReadUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lucky.IoC
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddLuckyServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LuckyDb"));
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddMediatR(conf => {
                conf.RegisterServicesFromAssembly(typeof(CreateUserInteractor).Assembly);
            });
            services.AddMediatR(conf => {
                conf.RegisterServicesFromAssembly(typeof(ReadUserInteractor).Assembly);
            });
            //services.AddValidatorsFromAssembly(typeof(CreateOrderValidator).Assembly);
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}