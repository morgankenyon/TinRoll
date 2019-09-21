using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        readonly string SpecificOrigins = "_specificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<TinRollContext>(
                options => options.UseSqlServer(@"Server=DESKTOP-P0PO0N5\MSSQLLOCALDB;Database=TinRollDb;Trusted_Connection=True;MultipleActiveResultSets=true"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TinRoll API", Version = "v1" });
            });

            // services.AddCors(c =>
            // {
            //     c.AddPolicy(SpecificOrigins,
            //         builder =>
            //         {
            //             builder.AllowAnyOrigin()//.WithOrigins("http://localhost:8080")
            //                 .AllowAnyHeader()
            //                 .AllowAnyMethod();
            //         });
            // });

            services.AddCors();

            MapDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TinRoll API V1");
            });
            app.UseCors(builder => builder.WithOrigins("http://localhost:8080"));
            app.UseMvc();

        }

        private void MapDependencyInjection(IServiceCollection services)
        {            
            //managers
            services.AddScoped<IQuestionManager, QuestionManager>();
            services.AddScoped<IUserManager, UserManager>();

            //repos
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}
