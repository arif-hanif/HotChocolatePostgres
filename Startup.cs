using HotChocolatePostgres.Data;
using  HotChocolate;
using HotChocolate.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolatePostgres
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // If you need dependency injection with your query object add your query type as a services.
            // services.AddSingleton<Query>();

            services
                .AddPooledDbContextFactory<AppDbContext>(
                    options => options.UseNpgsql(
                        "Host=localhost;Database=sandbox01;Username=user;Password=password1"))
                .AddRouting()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections()
                .AddPostgresProjections();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseRouting()
                .UseEndpoints(endpoint => endpoint.MapGraphQL());
        }
    }
}
