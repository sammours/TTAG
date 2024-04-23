namespace TTAK
{
    using System.Text;
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using TTAG.App.MappingProfiles;
    using TTAG.Domain.Profile.Helpers;
    using TTAG.Domain.Repository;
    using TTAG.Domain.Service;

    public class Startup
    {
        private readonly string allowOrigins = "AllowOrigins";

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string securitykey = "this_TTAG_securitykey!@#$%^";
            var symmetricsecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "TTAG_App",
                        ValidAudience = "TTAG_Users",
                        IssuerSigningKey = symmetricsecuritykey,
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy(this.allowOrigins,
                        builder => builder.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            services.TryAddScoped<IArtRepository, ArtRepository>();
            services.TryAddScoped<IArtistRepository, ArtistRepository>();
            services.TryAddScoped<IUserRepository, UserRepository>();
            services.TryAddScoped<IUserService, UserService>();

            services.TryAddScoped<IProfileHelper, ProfileHelper>();

            services.AddControllers();
            services.AddSwaggerDocument();

            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(this.allowOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
