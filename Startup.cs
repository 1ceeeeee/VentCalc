using System;
using System.Linq;
using Angular2WebpackVisualStudio.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using VentCalc.Auth;
using VentCalc.Models;
using VentCalc.Persistence;
using VentCalc.Repositories;

namespace Angular2WebpackVisualStudio {
    public class Startup {
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: спрятать в конфиг и зашифровать
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(SecretKey));
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional : true, reloadOnChange : true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional : true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddScoped<IBuildingTypeRepository, BuildingTypeRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IRoomTypeValueRepository, RoomTypeValueRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork<VentCalcDbContext>>();
            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.AddAutoMapper();
            services.AddDbContext<VentCalcDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddCors(options => {
                options.AddPolicy("AllowAllOrigins",
                    builder => {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddIdentity<AppUser, IdentityRole>
                (o => {
                    // configure identity options
                    o.Password.RequireDigit = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<VentCalcDbContext>()
                .AddDefaultTokenProviders();

            // Add framework services.            
            services.AddMvc();

            // jwt wire up
            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options => {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim("rol", "api_access"));
            });
            // var tokenValidationParameters = new TokenValidationParameters {
            //     ValidateIssuer = true,
            //     ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

            //     ValidateAudience = true,
            //     ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

            //     ValidateIssuerSigningKey = true,
            //     IssuerSigningKey = _signingKey,

            //     RequireExpirationTime = false,
            //     ValidateLifetime = false,
            //     ClockSkew = TimeSpan.Zero
            // };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                    // Clock skew compensates for server time drift.
                    // We recommend 5 minutes or less:
                    ClockSkew = TimeSpan.FromMinutes(5),
                    // Specify the key used to sign the token:
                    IssuerSigningKey = _signingKey,
                    RequireSignedTokens = true,
                    // Ensure the token hasn't expired:
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    // Ensure the token audience matches our audience value (default true):
                    ValidateAudience = true,
                    ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
                    // Ensure the token was issued by a trusted authorization server (default true):
                    ValidateIssuer = true,
                    ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)]
                    };
                });
            // services.AddAuthorization(options => {
            //     options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
            // });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var angularRoutes = new [] {
                "/home",
                "/about"
            };

            app.Use(async(context, next) => {
                if (context.Request.Path.HasValue && null != angularRoutes.FirstOrDefault(
                        (ar) => context.Request.Path.Value.StartsWith(ar, StringComparison.OrdinalIgnoreCase))) {
                    context.Request.Path = new PathString("/");
                }

                await next();
            });

            app.UseCors("AllowAllOrigins");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}