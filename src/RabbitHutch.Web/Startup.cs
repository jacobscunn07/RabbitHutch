using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitHutch.Application.CommandHandlers;
using RabbitHutch.DataAccess;
using RabbitHutch.DataAccess.Raven;
using RabbitHutch.DataAccess.Raven.Indexes;
using Raven.Client.Documents;

namespace RabbitHutch.Web
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
            var ds = new DocumentStore
            {
                Urls = new[] {"http://localhost:8080"},
                Database = "RabbitHutch"
            }.Initialize();
            
            new MessageDocument_Search().Execute(ds);
            
            services.AddMediatR(typeof(ReplayMessageCommand).Assembly);
            services.AddSingleton<IDocumentStore>(ds);
            services.AddTransient<IDatabase, RavenDatabase>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{*url}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "api",
                    template: "api/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
