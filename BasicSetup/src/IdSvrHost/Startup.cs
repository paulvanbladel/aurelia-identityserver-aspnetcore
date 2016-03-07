﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdSvrHost.Configuration;
using IdSvrHost.Extensions;
using Microsoft.Extensions.PlatformAbstractions;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.AspNet.Authentication.Facebook;
using IdentityServer4.Core.Configuration;
using IdentityServer4.Core.Services.Default;
namespace IdSvrHost
{
    public class Startup
    {
        private readonly IApplicationEnvironment _environment;
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IApplicationEnvironment environment)
        {
            _environment = environment;

            var builder = new ConfigurationBuilder()
              .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            var cert = new X509Certificate2(Path.Combine(_environment.ApplicationBasePath, "idsrv4test.pfx"), "idsrv3test");

            var builder = services.AddIdentityServer(options =>
            {
                options.SigningCertificate = cert;
                options.RequireSsl = false;
                options.SiteName = "IDS";
                options.Endpoints.EnableIdentityTokenValidationEndpoint = true;
                

                options.EventsOptions = new IdentityServer4.Core.Configuration.EventsOptions
                {
                    RaiseSuccessEvents = true,
                    RaiseErrorEvents = true,
                    RaiseFailureEvents = true,
                    RaiseInformationEvents = true
                };
                

            });

            builder.AddInMemoryClients(Clients.Get());
            builder.AddInMemoryScopes(Scopes.Get());

            builder.AddInMemoryUsers(Users.Get());
            builder.AddCustomGrantValidator<CustomGrantValidator>();
            
            // for the UI
            services
                .AddMvc()
                .AddRazorOptions(razor =>
                {
                    razor.ViewLocationExpanders.Add(new IdSvrHost.UI.CustomViewLocationExpander());
                });
            services.AddTransient<IdSvrHost.UI.Login.LoginService>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {

            loggerFactory.AddConsole(LogLevel.Verbose);
            loggerFactory.AddDebug(LogLevel.Verbose);
            app.UseDeveloperExceptionPage();
            app.UseIISPlatformHandler();




            //TODO refine CORS
            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });

           

            app.UseIdentityServer();
          


            app.UseStaticFiles();
           
            app.UseMvcWithDefaultRoute();
        }

        private void ConfigureAdditionalIdProviders(IApplicationBuilder app)
        {
            //var fbAuthOptions = new FacebookAuthenticationOptions
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
