﻿using Common.Api;
using Common.API;
using Common.Domain.Base;
using Hangfire;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Seed.HangFire.Config;
using System;
using System.Collections.Specialized;

namespace Seed.HangFire
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConfigSettingsBase>(Configuration.GetSection("ConfigSettings"));
            services.Configure<Connectionstring>(Configuration.GetSection("ConfigConnectionString"));
            services.AddSingleton<IConfiguration>(Configuration);

            var authorityEndPoint = Configuration.GetSection("ConfigSettings:AuthorityEndPoint").Value;
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";

                options.Authority = authorityEndPoint;
                options.RequireHttpsMetadata = false;

                options.ClientId = "hangfire-dash";
                options.SaveTokens = true;
            });

            // Add cross-origin resource sharing services Configurations
            Cors.Enable(services);

            var connectionString = Configuration.GetSection("ConfigConnectionString:Default").Value;
            services.AddHangfire(x => x.UseSqlServerStorage(connectionString));

            // Add application services.
            ConfigContainer.Config(services);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            ILoggerFactory loggerFactory,
            IApplicationBuilder app,
            IHostingEnvironment env,
            IServiceProvider serviceProvider, 
            IOptions<ConfigSettingsBase> configSettingsBase)
        {
            app.UseHangfireServer();
            app.UseAuthentication();
            app.UseHangfireDashboard("/jobs", new DashboardOptions
            {
                Authorization = new[] { new AuthoritionDashboardFilter() }
            });

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            // Configure hangfire to use the new JobActivator we defined.
            GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(serviceProvider));
            
            //Sample HTTP JOB
            var apiEndPoint = configSettingsBase.Value.ApiEndPoint;
            var authorityEndPoint = configSettingsBase.Value.AuthorityEndPoint;
            RecurringJob.AddOrUpdate(() => ExecuteCallHttProcess(authorityEndPoint, apiEndPoint), Cron.Daily);
        }

        public void ExecuteCallHttProcess(string authorityEndPoint, string apiEndPoint)
        {

            if (authorityEndPoint.IsNullOrEmpty() || apiEndPoint.IsNullOrEmpty())
                return;

            var request = DefineRequest(authorityEndPoint, apiEndPoint);
            var response = request.Get<dynamic>("Health/Ping", new NameValueCollection
            {
                {"AttributeBehavior","Ping"},
            });
        }

        private Request DefineRequest(string authorityEndPoint, string apiEndPoint)
        {
            var request = new Request();
            request.SetAddress(apiEndPoint);
            request.AddHeaders("Content-Type:application/json");
            var accessToken = this.GetAccessToken(authorityEndPoint);
            request.SetBearerToken(accessToken);
            return request;
        }

        public string GetAccessToken(string authorityEndPoint)
        {
            var _client = new TokenClient(authorityEndPoint + "/connect/token", "hangfire-api", "segredo");
            var token = _client.RequestClientCredentialsAsync("ssosa").Result;
            return token.AccessToken;
        }
    }
}
