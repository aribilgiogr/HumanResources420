using Business.Services;
using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Core.Utils;
using Data;
using Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class IoC
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(configuration.GetConnectionString("data")));

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MapProfiles>();
            });

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJobPostingService, JobPostingService>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();

            return services;
        }
    }
}
