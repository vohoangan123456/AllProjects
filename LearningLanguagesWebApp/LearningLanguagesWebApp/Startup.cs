using Languages.Business;
using Languages.Business.Common;
using Languages.Common;
using Languages.Common.Interfaces;
using Languages.Data.Common;
using Languages.Data.Common.Interfaces;
using Languages.Data.Query;
using Languages.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningLanguagesWebApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


            // Repositories
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<ILanguagesConfiguration, LanguagesConfiguration>();
            services.AddTransient<IApplicationConfigurationManager, ApplicationConfigurationManager>();

            //services
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IWordsService, WordsService>();
            services.AddTransient<IImageUploader, ImageUploader>();

            //procedures
            services.AddTransient<ICategoriesProcedures, CategoriesProcedures>();
            services.AddTransient<IWordsProcedures, WordsProcedures>();

            //data layers
            services.AddTransient<ICategoriesDatalayer, CategoriesDatalayer>();
            services.AddTransient<IWordsDatalayer, WordsDatalayer>();
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
