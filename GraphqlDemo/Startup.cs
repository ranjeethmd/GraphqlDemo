using GraphqlDemo.Attendees;
using GraphqlDemo.Conferences;
using GraphqlDemo.Sessions;
using GraphqlDemo.Tags;
using GraphqlDemo.Tracks;
using GraphqlDemo.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;

namespace GraphqlDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services )
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            services.AddAuthorization(options => options.AddPolicy("CanReadGraph", policy => policy.RequireAssertion(context => 
                context.User.HasClaim(c => c.Type == "http://schemas.microsoft.com/identity/claims/scope" && c.Value == "Graph.Read")
            
            )));

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services
                .AddGraphQLServer()
                .AddAuthorization()
                .AddGlobalObjectIdentification()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<SessionQueries>()
                .AddTypeExtension<SpeakerQueries>()
                .AddTypeExtension<TrackQueries>()
                .AddTypeExtension<ConferenceQueries>()
                .AddTypeExtension<TagQueries>()
                .AddTypeExtension<AttendeeQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<SessionMutations>()
                    .AddTypeExtension<SpeakerMutations>()
                    .AddTypeExtension<TrackMutations>()
                    .AddTypeExtension<ConferenceMutations>()
                    .AddTypeExtension<TagMutations>()
                    .AddTypeExtension<AttendeeMutations>()               
                .AddType<AttendeeType>()
                .AddType<SessionType>()
                .AddType<SpeakerType>()
                .AddType<TrackType>()
                .AddType<ConferenceType>()
                .AddType<TagType>();    


            services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=conferences.db"));

            services.AddLogging();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();    

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {    
                endpoints.MapGraphQL();               
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
