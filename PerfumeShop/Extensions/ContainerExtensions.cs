using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using PerfumeShop.API.Core;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using System.Text;
using Newtonsoft.Json;
using PerfumeShop.Application.Logging;
using PerfumeShop.Application.UseCases.Commands.BrandCommands;
using PerfumeShop.Application.UseCases.Commands.PerfumeCommands;
using PerfumeShop.Application.UseCases.Commands.UserCommands;
using PerfumeShop.Implementation.Logging;
using PerfumeShop.Implementation.UseCases.Commands.EF.Brands;
using PerfumeShop.Implementation.UseCases.Commands.EF.Users;
using PerfumeShop.Implementation.Validations.BrandValidations;
using PerfumeShop.Implementation.Validations.UserValidations;
using PerfumeShop.Implementation.UseCases.UseCaseLogger;
using PerfumeShop.Application.UseCases.Queries.Brands;
using PerfumeShop.Application.UseCases.Queries.Perfumes;
using PerfumeShop.Application.UseCases.Queries.Users;
using PerfumeShop.Implementation.UseCases.Commands.EF.Perfumes;
using PerfumeShop.Implementation.UseCases.Queries.EF.Brands;
using PerfumeShop.Implementation.UseCases.Queries.EF.Perfumes;
using PerfumeShop.Implementation.UseCases.Queries.EF.Users;
using PerfumeShop.Implementation.Validations.PerfumeValidations;

namespace PerfumeShop.API.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<PerfumeContext>();
                var settings = x.GetService<AppSettings>();

                return new JwtManager(context, settings.JwtSettings);
            });


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddApplicationUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                //Pristup payload-u
                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new AnonymousUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    // "[1, 2, 3, 4, 5]"
                    UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
                };

                return actor;
            });
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<ICreateBrand, EfCreateBrand>();
            services.AddTransient<IUpdateBrand, EfUpdateBrand>();
            services.AddTransient<IDeleteBrand, EfDeleteBrand>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IFindBrandQuery, EfFindBrandQuery>();
            services.AddTransient<IGetPerfumesQuery, EfGetPerfumesQuery>();
            services.AddTransient<IFindPerfumeQuery, EfFindPerfumeQuery>();
            services.AddTransient<ICreatePerfumeCommand, EfCreatePerfumeCommand>();
            services.AddTransient<IRemovePerfumeCommand, EfRemovePerfumeCommand>();

            #region Validators
            services.AddTransient<CreateBrandValidation>();
            services.AddTransient<UpdateBrandValidation>();
            services.AddTransient<DeleteBrandValidation>();
            services.AddTransient<CreateUserValidation>();
            services.AddTransient<CreatePerfumeValidation>();
            #endregion
        }
    }
}
