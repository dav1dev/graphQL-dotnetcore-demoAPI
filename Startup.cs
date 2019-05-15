using System;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLDemoAPI.Data;
using GraphQLDemoAPI.GraphQL;
using GraphQLDemoAPI.GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLDemoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ApplicationDbContext>(context =>
            {
                context.UseInMemoryDatabase("GraphQL");
            });

            // TODO 06: register services
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<CommentType>();
            services.AddSingleton<PostType>();
            services.AddSingleton<UserType>();
            services.AddSingleton<SearchInterface>();
            services.AddSingleton<SearchUnion>();
            services.AddScoped<BlogQuery>();
            services.AddScoped<ISchema, BlogSchema>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // TODO 02: activate graph i QL
                app.UseGraphiQl("/graphql");
            }
            else
            {
                throw new NotSupportedException();
            }

            app.UseMvc();
        }
    }
}
