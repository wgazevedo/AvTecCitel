using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoTec_APICore.Business.Components;
using AvaliacaoTec_APICore.Data.Context;
using AvaliacaoTec_APICore.Data.Repository;
using AvaliacaoTec_APICore.Data.Structure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AvaliacaoTec_APICore
{
    /// <summary>
    /// Startup configuration
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// Startup constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// IConfiguration instance
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<EntityContext>(op => op.UseMySql(Configuration.GetConnectionString("AvaliacaoTec")));

            services.AddCors(setup =>
            {
                setup.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                    builder.WithExposedHeaders("x-page", "x-page-length", "x-page-count", "x-total-records");
                });
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("CorsPolicy"));
            });

            ConfigureVersioning(services);
            ConfigureSwagger(services);
            ConfigureComponents(services);
            ConfigureRepositories(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
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

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    s.SwaggerEndpoint
                    (
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant()
                    );
                }

                s.DocExpansion(DocExpansion.List);
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        /// <summary>
        /// Configuring Swagger
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureSwagger(IServiceCollection services)
        {
            var swaggerXMLPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{PlatformServices.Default.Application.ApplicationName}.xml");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "AvaliacaoTec_APICore",
                    Description = "Avaliação tecnica Sitel.",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Wellington Gonçalves de Azevedo", Email = "wellington.azevedo@outlook.com" }
                });

                //c.IncludeXmlComments(swaggerXMLPath);
            });
        }

        /// <summary>
        /// Configure controller's versioning
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(1, 0);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });
        }

        /// <summary>
        /// Configures all dependency injections for business components
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureComponents(IServiceCollection services)
        {
            services.AddScoped<CategoriaComponent>();
            services.AddScoped<ProdutoComponent>();
        }

        /// <summary>
        /// Configures all dependency injections for repository components
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
