using GraphqlDemo.Data;
using GraphqlDemo.DataLoader;
using GraphqlDemo.Extensions;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphqlDemo.Types
{
    public class SessionType : ObjectType<Session>
    {
        protected override void Configure(IObjectTypeDescriptor<Session> descriptor)
        {
            descriptor
                .Authorize("CanReadGraph")
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<SessionByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Authorize("CanReadGraph")
                .Field(t => t.SessionSpeakers)
                .ResolveWith<SessionResolvers>(t => t.GetSpeakersAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("speakers");

            descriptor
                .Authorize("CanReadGraph")
                .Field(t => t.SessionAttendees)
                .ResolveWith<SessionResolvers>(t => t.GetAttendeesAsync(default!, default!, default!, default))
                .UseDbContext<ApplicationDbContext>()
                .Name("attendees");

            descriptor
               .Authorize("CanReadGraph")
               .Field(t => t.SessionTags)
               .ResolveWith<SessionResolvers>(t => t.GetTagsAsync(default!, default!, default!, default))
               .UseDbContext<ApplicationDbContext>()
               .Name("tags");

            descriptor
                .Authorize("CanReadGraph")
                .Field(t => t.Track)
                .ResolveWith<SessionResolvers>(t => t.GetTrackAsync(default!, default!, default))
                .Name("track");

            descriptor
                .Authorize("CanReadGraph")
                .Field(t => t.TrackId)
                .ID(nameof(Track));

            descriptor
                .Authorize("CanReadGraph")
                .Field(t => t.Conference)
                .ResolveWith<SessionResolvers>(t => t.GetConferenceAsync(default!, default!, default))
                .Name("conference");
        }

        private class SessionResolvers
        {
            public async Task<IEnumerable<Speaker>> GetSpeakersAsync(
                [Parent] Session session,
                [ScopedService] ApplicationDbContext dbContext,
                SpeakerByIdDataLoader speakerById,
                CancellationToken cancellationToken)
            {
                int[] speakerIds = await dbContext.Sessions
                    .Where(s => s.Id == session.Id)
                    .Include(s => s.SessionSpeakers)
                    .SelectMany(s => s.SessionSpeakers.Select(t => t.SpeakerId))
                    .ToArrayAsync();

                return await speakerById.LoadAsync(speakerIds, cancellationToken);
            }

            public async Task<IEnumerable<Attendee>> GetAttendeesAsync(
                [Parent] Session session,
                [ScopedService] ApplicationDbContext dbContext,
                AttendeeByIdDataLoader attendeeById,
                CancellationToken cancellationToken)
            {
                int[] attendeeIds = await dbContext.Sessions
                    .Where(s => s.Id == session.Id)
                    .Include(session => session.SessionAttendees)
                    .SelectMany(session => session.SessionAttendees.Select(t => t.AttendeeId))
                    .ToArrayAsync();

                return await attendeeById.LoadAsync(attendeeIds, cancellationToken);
            }

            public async Task<Track?> GetTrackAsync(
                [Parent] Session session,
                TrackByIdDataLoader trackById,
                CancellationToken cancellationToken)
            {
                if (session.TrackId is null)
                {
                    return null;
                }

                return await trackById.LoadAsync(session.TrackId.Value, cancellationToken);
            }

            public async Task<Conference?> GetConferenceAsync(
                [Parent] Session session,
                ConferenceByIdDataLoader conferenceById,
                CancellationToken cancellationToken)
            {
                if (!session.ConferenceId.HasValue)
                    return null;

                return await conferenceById.LoadAsync(session.ConferenceId.Value, cancellationToken);
            }

            public async Task<IEnumerable<Tag?>> GetTagsAsync(
                [Parent] Session session,
                [ScopedService] ApplicationDbContext dbContext,
                TagByIdDataLoader tagById,
                CancellationToken cancellationToken)
            {
                var ids = await dbContext.Sessions
                    .Where(s => s.Id == session.Id)
                    .Include(session => session.SessionTags)
                    .SelectMany(session => session.SessionTags.Select(t => t.TagId))
                    .ToArrayAsync();

                return await tagById.LoadAsync(ids, cancellationToken);
            }
        }
    }
}
