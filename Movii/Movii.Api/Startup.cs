using FluentValidation;
using FluentValidation.AspNetCore;
using Movii.Api.Middlewares;
using Movii.Api.BindingModels;
using Movii.Api.Middlewares;
using Movii.Data.Sql;
using Movii.Data.Sql.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movii.Api.Validation;
using Movii.Data.Sql.Client;
using Movii.IData.Client;
using Movii.IServices.Client;
using Movii.IServices.Requests;
using Movii.Services.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CreateClient = Movii.Api.BindingModels.CreateClient;
using EditClient = Movii.Api.BindingModels.EditClient;

namespace Movii.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors((setup) =>
                {
                    setup.AddPolicy("default", (options) =>
                    {
                        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                    });
                });
            services.AddDbContext<MoviiDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("MoviiDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddControllers()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation();
            services.AddTransient<IValidator<EditClient>, EditClientValidator>();
            services.AddTransient<IValidator<CreateClient>, CreateClientValidator>();
            services.AddTransient<IValidator<UpdateClientAddress>, UpdateClientAddressValidator>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddApiVersioning( o =>
            {
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MoviiDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();
                
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();
            }

            app.UseCors("default");
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}