using GraphQL.POC.API.Contracts;
using GraphQL.POC.API.Entities.Context;
using GraphQL.POC.API.GraphQL.GraphQLSchema;
using GraphQL.POC.API.Repository;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL.POC.API
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
            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("sqlConString")));
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<AppSchema>();
            services.AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped)
                .AddDataLoader();

            services.AddControllers().AddNewtonsoftJson(o=>o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseGraphQL<AppSchema>();
            app.UseGraphQLPlayground(options: new Server.Ui.Playground.GraphQLPlaygroundOptions());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
