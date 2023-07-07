using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions
{
    public static class ApplicationServiceExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ITokenService, TokenService>();
            services.AddCors(opt =>

                        {

                            opt.AddPolicy("CorsPolicy", policy =>

                            {

                                policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("https://localhost:4200");

                            });

                        });
            return services;
        }
    }
}