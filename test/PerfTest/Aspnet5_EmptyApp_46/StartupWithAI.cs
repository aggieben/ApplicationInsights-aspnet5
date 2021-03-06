﻿using Microsoft.ApplicationInsights.AspNet;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;

namespace Aspnet5_EmptyApp_46
{
    public class Startup2
    {
        public Startup2(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json");
        }

        public IConfiguration Configuration { get; set; }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry(Configuration);

            // Add MVC services to the services container.
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            // app.SetApplicationInsightsTelemetryDeveloperMode();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Request",
                    template: "{controller}/{action}/{loadTimeInMs}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
                    //defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
