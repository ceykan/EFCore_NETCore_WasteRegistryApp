using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WasteRegistry.API.Business;
using WasteRegistry.API.Data.DAL.Data;
using WasteRegistry.API.Data.DAL.Data.Interfaces;
using WasteRegistry.API.Data.DML;
using WasteRegistry.API.Token.Model;
using WasteRegistry.API.Token.Services;
using WasteRegistry.API.Token.Data;

namespace WasteRegistry.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connection = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContextPool<WasteRegistrationContext>(options => options.UseSqlServer(connection, b => b.EnableRetryOnFailure()));
            services.AddTransient<IWasteRegistrationRepository, WasteRegistrationRepository>();
            services.AddTransient<IWasteRegistryService, WasteRegistryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();


            services.Configure<AuthenticationOptions>(Configuration.GetSection("AuthenticationOptions"));
            var authenticationOptions = Configuration.GetSection("AuthenticationOptions").Get<AuthenticationOptions>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ValidIssuer = authenticationOptions.Issuer,
                    ValidAudience = authenticationOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationOptions.SecureKey))
                };
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , WasteRegistrationContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            db.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
