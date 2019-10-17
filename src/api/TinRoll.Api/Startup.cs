using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TinRoll.Data;
using TinRoll.Data.Repositories;
using TinRoll.Data.Repositories.Interfaces;
using TinRoll.Logic.Managers;
using TinRoll.Logic.Managers.Interfaces;

namespace TinRoll.Api
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
            services.AddDbContext<TinRollContext>(
                options => options.UseSqlServer(Configuration["TinRoll:SqlServer"]));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TinRoll API", Version = "v1" });
            });

            services.AddCors();

            MapDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TinRoll API V1");
                c.RoutePrefix = "";
            });
            app.UseCors(builder => builder.WithOrigins(Configuration["TinRoll:UIUrl"]).AllowAnyHeader().AllowAnyMethod());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private void MapDependencyInjection(IServiceCollection services)
        {            
            //managers
            services.AddScoped<IQuestionManager, QuestionManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IAnswerManager, AnswerManager>();
            services.AddScoped<ITagManager, TagManager>();

            //repos
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICreateQuestionRepository, CreateQuestionRepository>();
        }
    }
}
