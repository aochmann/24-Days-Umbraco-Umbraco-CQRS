using System;
using System.Diagnostics.CodeAnalysis;
using CleanArchitecture.MembersRegistration.Application.Extensions;
using CleanArchitecture.MembersRegistration.Infrastructure.Extensions;
using CleanArchitecture.MembersRegistration.Web.DI;
using CleanArchitecture.Module.FeaturesManagementDashboard.Extensions;
using CleanArchitecture.SharedAbstractions.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

namespace CleanArchitecture.MembersRegistration.Web
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initialises a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="webHostEnvironment">The web hosting environment.</param>
        /// <param name="config">The configuration.</param>
        /// <remarks>
        /// Only a few services are possible to be injected here https://github.com/dotnet/aspnetcore/issues/9337.
        /// </remarks>
        public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config)
        {
            _env = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940.
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(swaggerOptions =>
            {
                swaggerOptions.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MembersRegistration.Api",
                    Version = "v1"
                });
            });

            _ = services
               .AddSingleton<IDependencyResolver, DependencyResolver>();

            RegisterUmbracoDependencies(services);
        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The web hosting environment.</param>
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(swaggerOptions =>
                {
                    swaggerOptions.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "MembersRegistration.Api v1");
                });
            }

            app.UseUmbraco()
                .WithMiddleware(u =>
                {
                    u.UseBackOffice();
                    u.UseWebsite();
                })
                .WithEndpoints(u =>
                {
                    u.UseInstallerEndpoints();
                    u.UseBackOfficeEndpoints();
                    u.UseWebsiteEndpoints();
                });
        }

        private void RegisterUmbracoDependencies([NotNull] IServiceCollection services)
            => services
               .AddUmbraco(_env, _config)
               .AddBackOffice()
               .AddWebsite()
               .AddComposers()
               .AddApplication()
               .AddInfrastructure()
               .AddFeaturesManagementDashboard()
               .Build();
    }
}