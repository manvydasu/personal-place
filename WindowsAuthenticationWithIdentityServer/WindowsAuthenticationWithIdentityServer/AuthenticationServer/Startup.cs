using AuthenticationServer.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthenticationServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        const string CorsPolicy = "AllowAll";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);

            services.AddIdentityServer()
                .AddExtensionGrantValidator<WindowsGrantValidator>()
                .AddInMemoryIdentityResources(IdentityServerConfiguration.Ids)
                .AddInMemoryApiResources(IdentityServerConfiguration.Apis)
                .AddInMemoryClients(IdentityServerConfiguration.Clients)
                .AddDeveloperSigningCredential();
            
            services.AddCors(o => o.AddPolicy(CorsPolicy, builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(CorsPolicy);

            app.UseIdentityServer();
        }
    }
}