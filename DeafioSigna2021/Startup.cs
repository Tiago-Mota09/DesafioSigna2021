using DeafioSigna2021.Data.Repositories;
using DeafioSigna2021.Domain.Models.Request;
using DeafioSigna2021.Logic;
using DeafioSigna2021.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeafioSigna2021
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
            #region :: FluentValidation ::
            //services.AddMvc(options => { options.Filters.Add(typeof(ValidateModelAttribute)); }).AddFluentValidation();
            services.AddScoped<IValidator<LikedRepositoryRequest>, LikedRepositoryValidator>();
            IServiceCollection serviceCollections = services.AddScoped<IValidator<LikedRepositoryRequest>, LikedRepositoryValidator>();
            services.AddScoped<IValidator<LikedRepositoryUpdateRequest>, LikedRepositoryUpdateValidator>();
            #endregion

            //#region :: Automapper ::
            //services.AddAutoMapper(typeof(Startup));
            //#endregion

            #region :: Swagger ::
            services.AddSwaggerGen(configuration =>
            {
                configuration.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "liberacao-acesso-celular.api",
                    Version = "v1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                configuration.IncludeXmlComments(xmlPath);
            });
            #endregion

            #region :: Dapper ::
            services.AddScoped<LikedRepositoryRepository>();

            DefaultTypeMap.MatchNamesWithUnderscores = true;
            #endregion

            #region :: Business ::
            services.AddTransient<LikedRepositoryBL>();
            #endregion

            services.AddMvc();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
