using GraphqlDemo.Attendees;
using GraphqlDemo.Conferences;
using GraphqlDemo.Sessions;
using GraphqlDemo.Tags;
using GraphqlDemo.Tracks;
using GraphqlDemo.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphqlDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGraphQLServer()
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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
