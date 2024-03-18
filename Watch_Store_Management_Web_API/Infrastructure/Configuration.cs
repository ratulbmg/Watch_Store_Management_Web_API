using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Watch_Store_Management_Web_API.BusinessLogicLayer.Services;
using Watch_Store_Management_Web_API.DataAccessLayer.Context;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Implementation;

namespace Watch_Store_Management_Web_API.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection RegisterServiceConfig(this IServiceCollection Service)
        {
            Service.AddScoped<IRepositoryWrapper, RepositoryWrapper>();


            Service.AddScoped<IProductService, ProductService>();
            Service.AddScoped<ICategoryService, CategoryService>();
            Service.AddScoped<IBrandService, BrandService>();
            Service.AddScoped<IAddressService, AddressService>();
            Service.AddScoped<IRoleService, RoleService>();
            Service.AddScoped<IUserService, UserService>();
            Service.AddScoped<IAuthService, AuthService>();
            Service.AddScoped<IOrderService, OrderService>();
            
            return Service;
        }

        public static void JWTServiceConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Audience = builder.Configuration["JWT:ValidAudience"];
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        // Skip the default logic and avoid using the default response
                        context.HandleResponse();
                        // Set the status code and write to the response
                        context.Response.StatusCode = 401;
                        return context.Response.WriteAsync("You are not authorized!");
                    }
                };
            });
        }

        public static void AutoMapperConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
        }

        public static void RegisterDBContextConfig(this WebApplicationBuilder builder)
        {
            // Add DBContext file after Swagger
            builder.Services.AddDbContext<WatchStoreDBContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConStr"))
            );
        }
    }
}
