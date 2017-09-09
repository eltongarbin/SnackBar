using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SnackBar.Api.Configurations;
using SnackBar.Api.Middlewares;
using SnackBar.Infra.CrossCutting.IoC;
using SnackBar.Infra.Data.Context;
using Swashbuckle.AspNetCore.Swagger;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace SnackBar.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnectionString = Configuration["ConnectionStrings:DefaultConnection"];
            bool useInMemoryProvider = bool.Parse(Configuration["Data:SnackBarConnection:InMemoryProvider"]);

            services.AddDbContext<SnackBarContext>(options =>
            {
                switch (useInMemoryProvider)
                {
                    case true:
                        options.UseInMemoryDatabase("SnackBar");
                        break;
                    default:
                        options.UseSqlServer(sqlConnectionString);
                        break;
                }
            });

            services.AddOptions();

            services.AddMvc(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                options.UseCentralRoutePrefix(new RouteAttribute("api/v{version}"));
            });

            services.AddAutoMapper();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SnackBar API",
                    Description = "API do site SnackBar",
                    TermsOfService = "Nenhum",
                    Contact = new Contact
                    {
                        Name = "Desenvolvedor Elton Nascimento",
                        Email = "eltongarbin@gmail.com",
                        Url = "http://snackbar.io"
                    },
                    License = new License
                    {
                        Name = "MIT",
                        Url = "http://snackbar.io/licensa"
                    }
                });
            });

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseMvc();

            if (env.IsProduction())
                app.UseSwaggerAuthorized();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "SnackBar API v1.0");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
