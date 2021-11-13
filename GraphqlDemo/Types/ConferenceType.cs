using GraphqlDemo.Data;
using GraphqlDemo.DataLoader;
using GraphqlDemo.Extensions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.Types
{
    public class ConferenceType: ObjectType<Conference>
    {
        protected override void Configure(IObjectTypeDescriptor<Conference> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<ConferenceByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));


            descriptor
                .Field(t => t.Sessions)
                .ResolveWith<ConfrenceResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("sessions");

            descriptor
                .Field(t => t.Tracks)
                .ResolveWith<ConfrenceResolvers>(t => t.GetTracksAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("tracks");

            descriptor
                .Field(t => t.Speakers)
                .ResolveWith<ConfrenceResolvers>(t => t.GetSpeakersAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("speakers");
            descriptor
                .Field(t => t.ConferenceAttendees)
                .ResolveWith<ConfrenceResolvers>(t => t.GetAttendeesAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("attendees");
        }

        private class ConfrenceResolvers
        {
            public async Task<IEnumerable<Session?>?> GetSessionsAsync(
                Conference confrence,
                [ScopedService] ApplicationDbContext dbContext,
                SessionByIdDataLoader sessionById,
                CancellationToken cancellationToken)
            {
                int[] sessionIds = await dbContext.Conferences
                    .Where(c => c.Id == confrence.Id)                    
                    .SelectMany(s => s.Sessions.Select(t => t.Id))
                    .ToArrayAsync();

                return await sessionById.LoadAsync(sessionIds, cancellationToken);
            }

            public async Task<IEnumerable<Track?>?> GetTracksAsync(
                Conference confrence,
                [ScopedService] ApplicationDbContext dbContext,
                TrackByIdDataLoader trackById,
                CancellationToken cancellationToken)
            {
                int[] trackIds = await dbContext.Conferences
                    .Where(c => c.Id == confrence.Id)
                    .SelectMany(s => s.Tracks.Select(t => t.Id))
                    .ToArrayAsync();

                return await trackById.LoadAsync(trackIds, cancellationToken);
            }

            public async Task<IEnumerable<Speaker?>?> GetSpeakersAsync(
               Conference confrence,
               [ScopedService] ApplicationDbContext dbContext,
               SpeakerByIdDataLoader speakerById,
               CancellationToken cancellationToken)
            {
                int[] speakerIds = await dbContext.Conferences
                    .Where(c => c.Id == confrence.Id)
                    .SelectMany(s => s.Speakers.Select(t => t.Id))
                    .ToArrayAsync();

                return await speakerById.LoadAsync(speakerIds, cancellationToken);
            }

            public async Task<IEnumerable<Attendee?>?> GetAttendeesAsync(
              Conference confrence,
              [ScopedService] ApplicationDbContext dbContext,
              AttendeeByIdDataLoader attendeesById,
              CancellationToken cancellationToken)
            {
                int[] attendeesIds = await dbContext.Conferences
                    .Where(c => c.Id == confrence.Id)
                    .Include(c => c.ConferenceAttendees)
                    .SelectMany(a => a.ConferenceAttendees.Select(t => t.AttendeeID))
                    .ToArrayAsync();

                return await attendeesById.LoadAsync(attendeesIds, cancellationToken);
            }
        }
    }
}
