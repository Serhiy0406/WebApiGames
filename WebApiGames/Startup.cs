using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiGames.Business.Interfaces;
using WebApiGames.Business.Services;
using WebApiGames.Data;
using WebApiGames.Data.Interfaces;
using WebApiGames.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using WebApiGames.Business.MapperProfile;

namespace WebApiGames
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
            //repository
            services.AddTransient<IGenresRepository, GenresRepository>();
            services.AddTransient<IBlogUsersRepository, BlogUserRepository>();
            services.AddTransient<IDevelopersRepository, DevelopersRepository>();
            services.AddTransient<IGamesRepository, GamesRepository>();
            services.AddTransient<IPublishersRepository, PublishersRepository>();
            services.AddTransient<IRatingsRepository, RatingsRepository>();

            services.AddTransient<IGenresRepository, GenresRepository>();
            services.AddDbContext<ApplicationContext>();
            //services.AddDbContext<ApplicationContext>(cfg =>
            //{
            //    cfg.UseSqlServer(Configuration.GetConnectionString("Default"));
            //});

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //service
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IDeveloperService, DeveloperService>();
            services.AddTransient<IBlogUserService, BlogUserService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<IRatingService, RatingService>();

            services.AddAutoMapper(typeof(SourceMappingProfile).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiGames", Version = "v1" });
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey
                //});
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiGames v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
